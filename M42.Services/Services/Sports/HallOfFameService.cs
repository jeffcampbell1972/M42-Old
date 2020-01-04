using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class HallOfFameService : IService<HallOfFame>
    {
        M42Context _m42;
        public HallOfFameService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<HallOfFame> Get()
        {
            throw new MethodUnsupportedException();
        }
        public HallOfFame Get(int id)
        {
            var hofData = _m42.HOFs
                .Include(x => x.Organization)
                .Include(x => x.Sport)
                .SingleOrDefault(x => x.Id == id);

            if (hofData == null)
            {
                throw new EntityNotFoundException();
            }
            var hofersData = _m42.HOFers
                .Include(x => x.Person)
                .Where(x => x.HOFId == id).OrderBy(x => x.YearInducted)
                .ToList();

            var hofers = hofersData.Select(x => new HallOfFamer
            {
                Id = x.Person.Id ,
                Identifier = x.Person.Identifier ,
                YearInducted = x.YearInducted , 
                Person = new Person { Id = x.Person.Id, Name = x.Person.ToString() },
                Positions = new List<Position>()
            })
            .ToList();

            var hofClasses = new List<HallOfFameClass>();

            foreach (var hofer in hofers)
            {
                //hofer.Positions = GetHoferPositions(hofer.Id, hofData.Sport.Id);

                var hofClass = hofClasses.SingleOrDefault(x => x.Year == hofer.YearInducted);

                if (hofClass == null)
                {
                    hofClass = new HallOfFameClass
                    {
                        Year = hofer.YearInducted,
                        HallOfFamers = new List<HallOfFamer> { hofer }
                    };

                    hofClasses.Add(hofClass);
                }
                else
                {
                    hofClass.HallOfFamers.Add(hofer);
                }
            }

            var hallOfFame = new HallOfFame
            {
                Id = hofData.Id,
                Identifier = hofData.Organization.Identifier ,
                Name = hofData.Organization.Name ,
                NumMembers = hofers.Count ,
                InauguralYear = hofers.Count > 0 ? hofers.First().YearInducted : 1900 ,
                Members = hofers ,
                Classes = hofClasses.OrderBy(x => x.Year).ToList()
            };

            return hallOfFame;
        }
        public HallOfFame Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(HallOfFame hallOfFame)
        {
            
        }
        public void Put(int id, HallOfFame hallOfFame)
        {
            throw new MethodUnsupportedException();
        }
        #region Build methods

        private List<Position> GetHoferPositions(int hoferId, int sportId)
        {
            var hoferPositions = _m42.TeamPlayerPositions
                .Where(x => x.TeamPerson.PersonId == hoferId && x.Position.SportId == sportId)
                .Select(x => x.Position)
                .Distinct()
                .ToList()
                .Select(x => new Position
                {
                    Id = x.Id,
                    Name = x.Name,
                    Abbreviation = x.Abbreviation,
                    SortOrder = x.SortOrder
                })
                .ToList();

            return hoferPositions;
        }


        #endregion
    }
}
