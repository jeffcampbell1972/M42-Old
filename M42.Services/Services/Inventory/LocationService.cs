using M42.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M42.SportsCards;

namespace M42.Inventory
{
    public class LocationService : IService<Location>
    {

        M42Context _m42;
        public LocationService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Location> Get()
        {
            var locationsData = _m42.Locations
               .OrderBy(x => x.Name).ToList();

            var locations = locationsData.Select(x => new Location
            {
                Id = x.Id,
                Identifier = x.Identifier,
                Name = x.Name
            })
            .ToList();

            return locations;
        }
        public Location Get(int id)
        {
            var locationData = _m42.Locations
                .SingleOrDefault(x => x.Id == id);

            if (locationData == null)
            {
                throw new Exception("Invalid Id to Locations provided.");
            }

            var location = new Location
            {
                Id = locationData.Id,
                Identifier = locationData.Identifier ,
                Name = locationData.Name
            };

            return location;
        }
        public Location Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Location location)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Location location)
        {
            throw new MethodUnsupportedException();
        }
    }
}
