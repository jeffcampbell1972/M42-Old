using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M42.SPA.Sports;

namespace M42.SPA.Sports
{
    public static class SportsBuilder
    {    
        public static IEnumerable<Sport> GetSports(IService<M42.Sports.Sport> sportsService)
        {
            var sportsData = sportsService.Get();

            var sports = 
                sportsData
                .Select(x => new Sport 
                { 
                    Id = x.Id, 
                    Identifier = x.Identifier, 
                    Name = x.Name
                })
                .ToList()
                .ToArray();

            return sports;
        }
        public static Sport GetSport(IService<M42.Sports.Sport> sportsService, int id)
        {
            var sportData = sportsService.Get(id);

            var sport = new Sport
            {
                Id = sportData.Id,
                Identifier = sportData.Identifier,
                Name = sportData.Name
            };

            return sport;
        }
    }
}
