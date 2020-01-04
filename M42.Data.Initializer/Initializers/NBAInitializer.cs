using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public static class NBAInitializer
    {
        public static void Seed(M42Context m42)
        {
            SeedLeagues(m42);
            SeedConferences(m42);
            SeedPositions(m42);
            SeedStatistics(m42);
            SeedFranchises(m42);
            SeedSeasons(m42);
            SeedTeams(m42);
        }
        private static void SeedLeagues(M42Context context)
        {
            int basketballHOFId = context.HOFs.Include(x => x.Organization).Single(x => x.Organization.Identifier == "Basketball-HOF").Id;

            DataService.AddLeague(context, "NBA", "National Basketball Association", "NBA", Sport.Basketball.Id, basketballHOFId,  1946);

            context.SaveChanges();
        }
        private static void SeedConferences(M42Context context)
        {
            int nbaId = context.Leagues.Single(x => x.Abbreviation == "NBA").Id;

            DataService.AddConference(context, "NBAEast", nbaId, "Eastern", 1);
            DataService.AddConference(context, "NBAWest", nbaId, "Western", 2);

            context.SaveChanges();
        }
        private static void SeedDivisions(M42Context context)
        {
            int nbaeId = context.Conferences.Single(x => x.Identifier == "NBAEast").Id;
            int nbawId = context.Conferences.Single(x => x.Identifier == "NBAWest").Id;

        }
        private static void SeedPositions(M42Context context)
        {
            DataService.AddPosition(context, "Basketball-G", "Guard", "G", Sport.Basketball.Id, 1 );
            DataService.AddPosition(context, "Basketball-C", "Center", "C", Sport.Basketball.Id, 1 );
            DataService.AddPosition(context, "Basketball-F", "Forward", "F", Sport.Basketball.Id, 1 );

        }
        private static void SeedStatistics(M42Context context)
        {

        }
        private static void SeedFranchises(M42Context context)
        {
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Toronto Rapters", true, "NBA-Rapters"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Philadelphia 76ers", true, "NBA-76ers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Boston Celtics", true, "NBA-Celtics"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "New Jersey Nets", true, "NBA-Nets"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "New York Knicks", true, "NBA-Knicks"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Milwaukee Bucks", true, "NBA-Bucks"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Indiana Pacers", true, "NBA-Pacers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Detroit Pistons", true, "NBA-Pistons"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Chicago Bulls", true, "NBA-Bulls"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Cleveland Cavaliers", true, "NBA-Cavaliers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Orlando Magic", true, "NBA-Magic"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Charlotte Hornets", true, "NBA-Hornets"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Miami Heat", true, "NBA-Heat"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Washington Wizards", true, "NBA-Wizards"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Atlanta Hawks", true, "NBA-Hawks"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Golden State Warriors", true, "NBA-Warriors"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Los Angeles Clippers", true, "NBA-Clippers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Sacramento Kings", true, "NBA-Kings"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Los Angeles Lakers", true, "NBA-Lakers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Phoenix Suns", true, "NBA-Suns"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Houston Rockets", true, "NBA-Rockets"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "San Antonio Spurs", true, "NBA-Spurs"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Nashville Grizzlies", true, "NBA-Grizzlies"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "New Orleans Pelicans", true, "NBA-Pelicans"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Dallas Mavericks", true, "NBA-Mavericks"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Denver Nuggets", true, "NBA-Nuggets"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Portland Trail Blazers", true, "NBA-TrailBlazers"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Utah Jazz", true, "NBA-Jazz"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Oklahoma City Thunder", true, "NBA-Thunder"  );
            DataService.AddFranchise(context, Sport.Basketball.Id, true, "Minnesota Timerwolves", true, "NBA-Timerwolves"  );

            context.SaveChanges();
        }
        private static void SeedSeasons(M42Context context)
        {
            int nbaId = context.Organizations.Single(x => x.Identifier == "NBA").Id;

            DataService.AddSeason(context, nbaId, 1946, 11, 60, "Basketball Association of America", "BAA", null, null, "NBA1946" );
            DataService.AddSeason(context, nbaId, 1947, 8, 48, "Basketball Association of America", "BAA", null, null, "NBA1947" );
            DataService.AddSeason(context, nbaId, 1948, 12, 60, "Basketball Association of America", "BAA", null, null, "NBA1948" );
            DataService.AddSeason(context, nbaId, 1949, 17, 68, null, null, null, null, "NBA1949" );
            DataService.AddSeason(context, nbaId, 1950, 11, 68, null, null, null, null, "NBA1950" );
            DataService.AddSeason(context, nbaId, 1951, 10, 66, null, null, null, null, "NBA1951" );
            DataService.AddSeason(context, nbaId, 1952, 10, 70, null, null, null, null, "NBA1952" );
            DataService.AddSeason(context, nbaId, 1953, 9, 72, null, null, null, null, "NBA1953" );
            DataService.AddSeason(context, nbaId, 1954, 8, 72, null, null, null, null, "NBA1954" );
            DataService.AddSeason(context, nbaId, 1955, 8, 72, null, null, null, null, "NBA1955" );
            DataService.AddSeason(context, nbaId, 1956, 8, 72, null, null, null, null, "NBA1956" );
            DataService.AddSeason(context, nbaId, 1957, 8, 72, null, null, null, null, "NBA1957" );
            DataService.AddSeason(context, nbaId, 1958, 8, 72, null, null, null, null, "NBA1958" );
            DataService.AddSeason(context, nbaId, 1959, 8, 75, null, null, null, null, "NBA1959" );
            DataService.AddSeason(context, nbaId, 1960, 8, 79, null, null, null, null, "NBA1960" );
            DataService.AddSeason(context, nbaId, 1961, 9, 80, null, null, null, null, "NBA1961" );
            DataService.AddSeason(context, nbaId, 1962, 9, 80, null, null, null, null, "NBA1962" );
            DataService.AddSeason(context, nbaId, 1963, 9, 80, null, null, null, null, "NBA1963" );
            DataService.AddSeason(context, nbaId, 1964, 9, 80, null, null, null, null, "NBA1964" );
            DataService.AddSeason(context, nbaId, 1965, 9, 80, null, null, null, null, "NBA1965" );
            DataService.AddSeason(context, nbaId, 1966, 10, 80, null, null, null, null, "NBA1966" );
            DataService.AddSeason(context, nbaId, 1967, 12, 82, null, null, null, null, "NBA1967" );
            DataService.AddSeason(context, nbaId, 1968, 14, 82, null, null, null, null, "NBA1968" );
            DataService.AddSeason(context, nbaId, 1969, 14, 82, null, null, null, null, "NBA1969" );
            DataService.AddSeason(context, nbaId, 1970, 17, 82, null, null, null, null, "NBA1970" );
            DataService.AddSeason(context, nbaId, 1971, 17, 82, null, null, null, null, "NBA1971" );
            DataService.AddSeason(context, nbaId, 1972, 17, 82, null, null, null, null, "NBA1972" );
            DataService.AddSeason(context, nbaId, 1973, 17, 82, null, null, null, null, "NBA1973" );
            DataService.AddSeason(context, nbaId, 1974, 18, 82, null, null, null, null, "NBA1974" );
            DataService.AddSeason(context, nbaId, 1975, 18, 82, null, null, null, null, "NBA1975" );
            DataService.AddSeason(context, nbaId, 1976, 22, 82, null, null, null, null, "NBA1976" );
            DataService.AddSeason(context, nbaId, 1977, 22, 82, null, null, null, null, "NBA1977" );
            DataService.AddSeason(context, nbaId, 1978, 22, 82, null, null, null, null, "NBA1978" );
            DataService.AddSeason(context, nbaId, 1979, 22, 82, null, null, null, null, "NBA1979" );
            DataService.AddSeason(context, nbaId, 1980, 23, 82, null, null, null, null, "NBA1980" );
            DataService.AddSeason(context, nbaId, 1981, 23, 82, null, null, null, null, "NBA1981" );
            DataService.AddSeason(context, nbaId, 1982, 23, 82, null, null, null, null, "NBA1982" );
            DataService.AddSeason(context, nbaId, 1983, 23, 82, null, null, null, null, "NBA1983" );
            DataService.AddSeason(context, nbaId, 1984, 23, 82, null, null, null, null, "NBA1984" );
            DataService.AddSeason(context, nbaId, 1985, 23, 82, null, null, null, null, "NBA1985" );
            DataService.AddSeason(context, nbaId, 1986, 23, 82, null, null, null, null, "NBA1986" );
            DataService.AddSeason(context, nbaId, 1987, 23, 82, null, null, null, null, "NBA1987" );
            DataService.AddSeason(context, nbaId, 1988, 25, 82, null, null, null, null, "NBA1988" );
            DataService.AddSeason(context, nbaId, 1989, 27, 82, null, null, null, null, "NBA1989" );
            DataService.AddSeason(context, nbaId, 1990, 27, 82, null, null, null, null, "NBA1990" );
            DataService.AddSeason(context, nbaId, 1991, 27, 82, null, null, null, null, "NBA1991" );
            DataService.AddSeason(context, nbaId, 1992, 27, 82, null, null, null, null, "NBA1992" );
            DataService.AddSeason(context, nbaId, 1993, 27, 82, null, null, null, null, "NBA1993" );
            DataService.AddSeason(context, nbaId, 1994, 27, 82, null, null, null, null, "NBA1994" );
            DataService.AddSeason(context, nbaId, 1995, 29, 82, null, null, null, null, "NBA1995" );
            DataService.AddSeason(context, nbaId, 1996, 29, 82, null, null, null, null, "NBA1996" );
            DataService.AddSeason(context, nbaId, 1997, 29, 82, null, null, null, null, "NBA1997" );
            DataService.AddSeason(context, nbaId, 1998, 29, 50, null, null, null, null, "NBA1998" );
            DataService.AddSeason(context, nbaId, 1999, 29, 82, null, null, null, null, "NBA1999" );
            DataService.AddSeason(context, nbaId, 2000, 29, 82, null, null, null, null, "NBA2000" );
            DataService.AddSeason(context, nbaId, 2001, 29, 82, null, null, null, null, "NBA2001" );
            DataService.AddSeason(context, nbaId, 2002, 29, 82, null, null, null, null, "NBA2002" );
            DataService.AddSeason(context, nbaId, 2003, 29, 82, null, null, null, null, "NBA2003" );
            DataService.AddSeason(context, nbaId, 2004, 30, 82, null, null, null, null, "NBA2004" );
            DataService.AddSeason(context, nbaId, 2005, 30, 82, null, null, null, null, "NBA2005" );
            DataService.AddSeason(context, nbaId, 2006, 30, 82, null, null, null, null, "NBA2006" );
            DataService.AddSeason(context, nbaId, 2007, 30, 82, null, null, null, null, "NBA2007" );
            DataService.AddSeason(context, nbaId, 2008, 30, 82, null, null, null, null, "NBA2008" );
            DataService.AddSeason(context, nbaId, 2009, 30, 82, null, null, null, null, "NBA2009" );
            DataService.AddSeason(context, nbaId, 2010, 30, 82, null, null, null, null, "NBA2010" );
            DataService.AddSeason(context, nbaId, 2011, 30, 82, null, null, null, null, "NBA2011" );
            DataService.AddSeason(context, nbaId, 2012, 30, 82, null, null, null, null, "NBA2012" );
            DataService.AddSeason(context, nbaId, 2013, 30, 82, null, null, null, null, "NBA2013" );
            DataService.AddSeason(context, nbaId, 2014, 30, 82, null, null, null, null, "NBA2014" );
            DataService.AddSeason(context, nbaId, 2015, 30, 82, null, null, null, null, "NBA2015" );
            DataService.AddSeason(context, nbaId, 2016, 30, 82, null, null, null, null, "NBA2016" );
            DataService.AddSeason(context, nbaId, 2017, 30, 82, null, null, null, null, "NBA2017" );
            DataService.AddSeason(context, nbaId, 2018, 30, 82, null, null, null, null, "NBA2018" );
            DataService.AddSeason(context, nbaId, 2019, 30, 82, null, null, null, null, "NBA2019" );

            context.SaveChanges();
        }
        private static void SeedTeams(M42Context context)
        {
            //    int nbaId = context.Organizations.Single(x => x.Identifier == "NBA").Id;
            //    int season2019Id = context.Seasons.Single(x => x.LeagueId == nbaId && x.Year == 2019).Id;
            //    var franchises = context.Franchises.Include("Organization").Where(x => x.SportId == Sport.Basketball.Id);

            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Toronto", Name = " Rapters", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Rapters").Id, Identifier = "2019-NBA-Rapters" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Philadelphia", Name = " 76ers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-76ers").Id, Identifier = "2019-NBA-76ers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Boston", Name = " Celtics", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Celtics").Id, Identifier = "2019-NBA-Celtics" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "New Jersey", Name = " Nets", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Nets").Id, Identifier = "2019-NBA-Nets" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "New York", Name = " Knicks", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Knicks").Id, Identifier = "2019-NBA-Knicks" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Milwaukee", Name = " Bucks", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Bucks").Id, Identifier = "2019-NBA-Bucks" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Indiana", Name = " Pacers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Pacers").Id, Identifier = "2019-NBA-Pacers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Detroit", Name = " Pistons", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Pistons").Id, Identifier = "2019-NBA-Pistons" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Chicago", Name = " Bulls", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Bulls").Id, Identifier = "2019-NBA-Bulls" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Cleveland", Name = " Cavaliers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Cavaliers").Id, Identifier = "2019-NBA-Cavaliers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Orlando", Name = " Magic", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Magic").Id, Identifier = "2019-NBA-Magic" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Charlotte", Name = " Hornets", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Hornets").Id, Identifier = "2019-NBA-Hornets" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Miami", Name = " Heat", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Heat").Id, Identifier = "2019-NBA-Heat" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Washington", Name = " Wizards", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Wizards").Id, Identifier = "2019-NBA-Wizards" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Atlanta", Name = " Hawks", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Hawks").Id, Identifier = "2019-NBA-Hawks" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Golden State", Name = " Warriors", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Warriors").Id, Identifier = "2019-NBA-Warriors" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Los Angeles", Name = " Clippers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Clippers").Id, Identifier = "2019-NBA-Clippers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Sacramento", Name = " Kings", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Kings").Id, Identifier = "2019-NBA-Kings" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Los Angeles", Name = " Lakers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Lakers").Id, Identifier = "2019-NBA-Lakers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Phoenix", Name = " Suns", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Suns").Id, Identifier = "2019-NBA-Suns" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Houston", Name = " Rockets", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Rockets").Id, Identifier = "2019-NBA-Rockets" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "San Antonio", Name = " Spurs", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Spurs").Id, Identifier = "2019-NBA-Spurs" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Nashville", Name = " Grizzlies", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Grizzlies").Id, Identifier = "2019-NBA-Grizzlies" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "New Orleans", Name = " Pelicans", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Pelicans").Id, Identifier = "2019-NBA-Pelicans" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Dallas", Name = " Mavericks", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Mavericks").Id, Identifier = "2019-NBA-Mavericks" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Denver", Name = " Nuggets", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Nuggets").Id, Identifier = "2019-NBA-Nuggets" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Portland", Name = " Trail Blazers", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-TrailBlazers").Id, Identifier = "2019-NBA-TrailBlazers" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Utah", Name = " Jazz", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Jazz").Id, Identifier = "2019-NBA-Jazz" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Oklahoma", Name = " City Thunder", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Thunder").Id, Identifier = "2019-NBA-Thunder" } );
            //    context.Teams.Add(new Team {  SeasonId = season2019Id,  City = "Minnesota", Name = " Timerwolves", FranchiseId = franchises.Single(x => x.Organization.Identifier == "NBA-Timerwolves").Id, Identifier = "2019-NBA-Timerwolves" } );
        }
    }
}