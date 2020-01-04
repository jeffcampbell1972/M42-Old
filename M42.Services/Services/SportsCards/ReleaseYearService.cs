using M42.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace M42.SportsCards
{
    public class ReleaseYearService : IReleaseYearService
    {
        M42Context _m42;
        public ReleaseYearService(M42Context m42)
        {
            _m42 = m42;
        }
        public ReleaseYear GetReleaseYear(string identifier)
        {
            string sportName = identifier.Split('-')[0];
            int year = Int32.Parse(identifier.Split('-')[1]);

            var sport = _m42.Sports.SingleOrDefault(x => x.Name == sportName);

            if(sport == null)
            {
                throw new Exception();
            }

            var releasesData = _m42.Releases
                .Include(x => x.League)
                .Include(x => x.Brand)
                .Include(x => x.Manufacturer)
                .Include(x => x.Manufacturer.Organization)
                .Where(x => x.Year == year && x.League.SportId == sport.Id)
                .OrderBy(x => x.Manufacturer.Organization.Name)
                .ThenBy(x => x.Brand.Name)
                .ToList();

            var releases = releasesData
                .Select(x => new Release
                {
                    Id = x.Id ,
                    Identifier = x.Identifier ,
                    Year = x.Year ,
                    Name = x.ToString() ,
                    Brand = new Brand { Id = x.Brand.Id, Identifier = x.Brand.Identifier, Name = x.Brand.Name } ,
                    Manufacturer = new Manufacturer {  Id = x.Manufacturer.Id, Identifier = x.Manufacturer.Organization.Identifier, Name = x.Manufacturer.Organization.Name }
                })
                .ToList();

            var manufacturers = releasesData
                .Select(x => x.Manufacturer)
                .Distinct()
                .ToList()
                .Select(x => new Manufacturer
                { 
                    Id = x.Id, 
                    Name = x.Organization.Name 
                })
                .ToList();

            var releaseYear = new ReleaseYear
            {
                Identifier = string.Format("{0}-{1}", sport.Name, year),
                Releases = releases,
                Manufacturers = manufacturers,
                Year = year,
                Sport = new Sports.Sport { Id = sport.Id, Identifier = sport.Name, Name = sport.Name },
                NumReleases = releases.Count,
                NumManufacturers = manufacturers.Count
            };

            return releaseYear;
        }
    }
}
