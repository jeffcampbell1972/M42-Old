using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public static class NCAAFInitializer
    {
        //private M42Context _m42;

        //public NCAAFInitializer(M42Context m42)
        //{
        //    _m42 = m42;
        //}
        public static void Seed(M42Context m42)
        {
            SeedLeagues(m42);
            SeedConferences(m42);
            SeedFranchises(m42);
            SeedConferences(m42);
            SeedDivisions(m42);
            SeedSeasons(m42);
            SeedTeams(m42);
        }
        private static void SeedLeagues(M42Context context)
        {
            int collegeHOFId = context.HOFs.Include(x => x.Organization).Single(x => x.Organization.Identifier == "NCAAF-HOF").Id;

            DataService.AddLeague(context, "NCAAF", "NCAA Football", "NCAAF", Sport.Football.Id, collegeHOFId, 1869);

            context.SaveChanges();
        }
        private static void SeedConferences(M42Context context)
        {
            int ncaafId = context.Leagues.Single(x => x.Abbreviation == "NCAAF").Id;

            DataService.AddConference(context, "ACC", ncaafId, "Atlantic Coast Conference", 1);
            DataService.AddConference(context, "AAC", ncaafId, "American Athletic Conference", 1);
            DataService.AddConference(context, "Big12", ncaafId, "Big 12", 1);
            DataService.AddConference(context, "BigTen", ncaafId, "Big Ten", 1);
            DataService.AddConference(context, "CUSA", ncaafId, "Conference USA", 1);
            DataService.AddConference(context, "Independent", ncaafId, "Independent", 1);
            DataService.AddConference(context, "Mid-American", ncaafId, "Mid-American", 1);
            DataService.AddConference(context, "MountainWest", ncaafId, "Mountain West", 1);
            DataService.AddConference(context, "PAC12", ncaafId, "PAC 12", 1);
            DataService.AddConference(context, "SEC", ncaafId, "Southeastern Conference", 1);
            DataService.AddConference(context, "Sun Belt", ncaafId, "Sun Belt", 1);

            context.SaveChanges();
        }
        private static void SeedDivisions(M42Context context)
        {
        }
        private static void SeedFranchises(M42Context context)
        {
            DataService.AddFranchise(context, Sport.Football.Id, false, "Virginia Tech", true, "VirginiaTech");
        }
        private static void SeedSeasons(M42Context context)
        {

        }
        private static void SeedTeams(M42Context context)
        {

        }
    }
}