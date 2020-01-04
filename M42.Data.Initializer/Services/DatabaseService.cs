using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public class DatabaseService : IDatabaseService
    {
        M42Context _m42;
        public DatabaseService(M42Context m42) 
        {
            _m42 = m42;
        }
        public bool IsSeeded()
        {
            if (_m42.Leagues.Count() > 0)
            {
                return true;
            }

            return false;
        }
        public void SeedDatabase()
        {
            PeopleInitializer.Seed(_m42);
            RolodexInitializer.Seed(_m42);
            EducationInitializer.Seed(_m42);
            
            SportsInitializer.Seed(_m42);
            NFLInitializer.Seed(_m42);
            MLBInitializer.Seed(_m42);
            NBAInitializer.Seed(_m42);
            NHLInitializer.Seed(_m42);
            NCAAFInitializer.Seed(_m42);
            //NCAABInitializer.Seed(_m42);

            SportsCardInitializer.Seed(_m42);
        }
       
    }
}



