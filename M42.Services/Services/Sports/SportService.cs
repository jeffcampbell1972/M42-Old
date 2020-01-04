using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class SportService : IService<Sport>
    {
        M42Context _m42;
        public SportService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Sport> Get()
        {
            var sports = _m42.Sports
                .Where(x => x.Id != M42.Data.Models.Sport.Golf.Id && x.Id != M42.Data.Models.Sport.Tennis.Id)
                .ToList()
                .Select(x => new M42.Sports.Sport 
                { 
                    Id = x.Id, 
                    Identifier = x.Name, 
                    Name = x.Name 
                })
                .ToList();

            return sports;
        }
        public Sport Get(int id)
        {
            var sportData = _m42.Sports.SingleOrDefault(x => x.Id == id);
                
            if (sportData == null)
            {
                throw new EntityNotFoundException();
            }
            var leagues = _m42.Leagues
                .Include(x => x.Organization)
                .Where(x => x.SportId == id && x.Organization.ActiveFlag)
                .ToList()
                .Select(x => new League 
                { 
                    Id = x.Id, 
                    Identifier = x.Organization.Identifier, 
                    Name = x.Organization.Name 
                })
                .ToList();

            var inactiveLeagues = _m42.Leagues
                .Include(x => x.Organization)
                .Where(x => x.SportId == id && !x.Organization.ActiveFlag)
                .ToList()
                .Select(x => new League
                {
                    Id = x.Id,
                    Identifier = x.Organization.Identifier,
                    Name = x.Organization.Name
                })
                .ToList();

            var positions = _m42.Positions
                .Where(x => x.SportId == id)
                .OrderBy(x => x.SortOrder)
                .Select(x => new Position
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name ,
                    SortOrder = x.SortOrder
                })
                .ToList();

            var hallsOfFame = _m42.HOFs
                .Include(x => x.Organization)
                .Where(x => x.SportId == id)
                .Select(x => new HallOfFame
                {
                    Id = x.Id,
                    Identifier = x.Organization.Identifier,
                    Name = x.Organization.Name
                })
                .ToList();

            var releaseYears = _m42.Releases
                .Select(x => x.Year)
                .Distinct()
                .ToList()
                .Select(x => new SportsCards.ReleaseYear 
                { 
                    Identifier = string.Format("{0}-{1}", sportData.Name, x) ,
                    Year = x 
                })
                .OrderBy(x => x.Year)
                .ToList();


            var sport = new Sport
            {
                Id = sportData.Id,
                Identifier = sportData.Name,
                Name = sportData.Name,
                Leagues = leagues ,
                InactiveLeagues = inactiveLeagues , 
                Positions = positions ,
                HallsOfFame = hallsOfFame ,
                ReleaseYears = releaseYears
            };

            return sport;
        }
        public Sport Get(string identifier)
        {
            var sportData = _m42.Sports.SingleOrDefault(x => x.Name == identifier);

            if (sportData == null)
            {
                throw new EntityNotFoundException();
            }

            return Get(sportData.Id);
        }
        public void Post(Sport player)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Sport player)
        {
            throw new MethodUnsupportedException();
        }

        #region private Build() methods
        #endregion
    }
}
