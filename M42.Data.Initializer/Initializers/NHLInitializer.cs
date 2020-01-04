using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public static class NHLInitializer
    {
        //private M42Context _m42;
        //public NHLInitializer(M42Context m42)
        //{
        //    _m42 = m42;
        //}
        public static void Seed(M42Context m42)
        {
            SeedLeagues(m42);
            SeedPositions(m42);
            SeedStatistics(m42);

            SeedFranchises(m42);
            SeedPeople(m42);
            SeedSeasons(m42);
            SeedTeams(m42);
        }
        private static void SeedLeagues(M42Context context)
        {
            int hockeyHOFId = context.HOFs.Include(x => x.Organization).Single(x => x.Organization.Identifier == "Hockey-HOF").Id;

            DataService.AddLeague(context, "NHL", "National Hockey League", "NHL", Sport.Hockey.Id, hockeyHOFId, 1917);

            context.SaveChanges();
        }
        private static void SeedConferences(M42Context context)
        {
            int nhlId = context.Leagues.Single(x => x.Abbreviation == "NHL").Id;

            DataService.AddConference(context, "NHLEast", nhlId, "Eastern", 1);
            DataService.AddConference(context, "NHLWest", nhlId, "Western", 2);

            context.SaveChanges();
        }
        private static void SeedDivisions(M42Context context)
        {
            int nhleId = context.Conferences.Single(x => x.Identifier == "NHLEast").Id;
            int nhlwId = context.Conferences.Single(x => x.Identifier == "NHLWest").Id;
        }
        private static void SeedPositions(M42Context context)
        {
            DataService.AddPosition(context, "Hockey-C", "Center", "C", Sport.Hockey.Id, 1 );
        }
        private static void SeedStatistics(M42Context context)
        {

        }
        private static void SeedFranchises(M42Context context)
        {
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Boston Bruins", true, "NHL-Bruins"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Buffalo Sabres", true, "NHL-Sabres"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Detroit Red Wings", true, "NHL-RedWings"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Dallas Stars", true, "NHL-Stars"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Florida Panthers", true, "NHL-Panthers"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Montreal Canadians", true, "NHL-Canadians"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Ottawa Senators", true, "NHL-Senators"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Tampa Bay Lightning", true, "NHL-Lightning"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Toronto Maple Leafs", true, "NHL-MapleLeafs"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Chicago Blackhawks", true, "NHL-Blackhawks"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Minnesota Wild", true, "NHL-Wild"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Nashville Predators", true, "NHL-Predators"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "St Louis Blues", true, "NHL-Blues"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Winnipeg Jets", true, "NHL-Jets"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Carolina Hurricanes", true, "NHL-Hurricanes"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Columbus Blue Jackets", true, "NHL-BlueJackets"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "New Jersey Devils", true, "NHL-Devils"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "New York Islanders", true, "NHL-Islanders"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "New York Rangers", true, "NHL-Rangers"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Philadelphia Flyers", true, "NHL-Flyers"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Pittsburgh Penguins", true, "NHL-Penguins"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Washington Capitals", true, "NHL-Capitals"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Arizona Coyotes", true, "NHL-Coyotes"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Anaheim Ducks", true, "NHL-Ducks"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Calgary Flames", true, "NHL-Flames"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Los Angeles Kings", true, "NHL-Kings"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "San Jose Sharks", true, "NHL-Sharks"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Vancouver Canucks", true, "NHL-Canucks"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Vegas Golden Knights", true, "NHL-GoldenKnights"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Colorado Avalanche", true, "NHL-Avalanche"  );
            DataService.AddFranchise(context, Sport.Hockey.Id, true, "Edmonton Oilers", true, "NHL-Oilers"  );

        }
        private static void SeedPeople(M42Context context)
        {

        }
        private static void SeedSeasons(M42Context context)
        {
            int nhlId = context.Leagues.Single(x => x.Abbreviation == "NHL").Id;

            DataService.AddSeason(context, nhlId, 1917, 30, 162, null, null, null, null, "NHL1917" );
            DataService.AddSeason(context, nhlId, 1918, 30, 162, null, null, null, null, "NHL1918" );
            DataService.AddSeason(context, nhlId, 1919, 30, 162, null, null, null, null, "NHL1919" );
            DataService.AddSeason(context, nhlId, 1920, 30, 162, null, null, null, null, "NHL1920" );
            DataService.AddSeason(context, nhlId, 1921, 30, 162, null, null, null, null, "NHL1921" );
            DataService.AddSeason(context, nhlId, 1922, 30, 162, null, null, null, null, "NHL1922" );
            DataService.AddSeason(context, nhlId, 1923, 30, 162, null, null, null, null, "NHL1923" );
            DataService.AddSeason(context, nhlId, 1924, 30, 162, null, null, null, null, "NHL1924" );
            DataService.AddSeason(context, nhlId, 1925, 30, 162, null, null, null, null, "NHL1925" );
            DataService.AddSeason(context, nhlId, 1926, 30, 162, null, null, null, null, "NHL1926" );
            DataService.AddSeason(context, nhlId, 1927, 30, 162, null, null, null, null, "NHL1927" );
            DataService.AddSeason(context, nhlId, 1928, 30, 162, null, null, null, null, "NHL1928" );
            DataService.AddSeason(context, nhlId, 1929, 30, 162, null, null, null, null, "NHL1929" );
            DataService.AddSeason(context, nhlId, 1930, 30, 162, null, null, null, null, "NHL1930" );
            DataService.AddSeason(context, nhlId, 1931, 30, 162, null, null, null, null, "NHL1932" );
            DataService.AddSeason(context, nhlId, 1932, 30, 162, null, null, null, null, "NHL1932" );
            DataService.AddSeason(context, nhlId, 1933, 30, 162, null, null, null, null, "NHL1933" );
            DataService.AddSeason(context, nhlId, 1934, 30, 162, null, null, null, null, "NHL1934" );
            DataService.AddSeason(context, nhlId, 1935, 30, 162, null, null, null, null, "NHL1935" );
            DataService.AddSeason(context, nhlId, 1936, 30, 162, null, null, null, null, "NHL1936" );
            DataService.AddSeason(context, nhlId, 1937, 30, 162, null, null, null, null, "NHL1937" );
            DataService.AddSeason(context, nhlId, 1938, 30, 162, null, null, null, null, "NHL1938" );
            DataService.AddSeason(context, nhlId, 1939, 30, 162, null, null, null, null, "NHL1939" );
            DataService.AddSeason(context, nhlId, 1940, 30, 162, null, null, null, null, "NHL1940" );
            DataService.AddSeason(context, nhlId, 1941, 30, 162, null, null, null, null, "NHL1941" );
            DataService.AddSeason(context, nhlId, 1942, 30, 162, null, null, null, null, "NHL1942" );
            DataService.AddSeason(context, nhlId, 1943, 30, 162, null, null, null, null, "NHL1943" );
            DataService.AddSeason(context, nhlId, 1944, 30, 162, null, null, null, null, "NHL1944" );
            DataService.AddSeason(context, nhlId, 1945, 30, 162, null, null, null, null, "NHL1945" );
            DataService.AddSeason(context, nhlId, 1946, 30, 162, null, null, null, null, "NHL1946" );
            DataService.AddSeason(context, nhlId, 1947, 30, 162, null, null, null, null, "NHL1947" );
            DataService.AddSeason(context, nhlId, 1948, 30, 162, null, null, null, null, "NHL1948" );
            DataService.AddSeason(context, nhlId, 1949, 30, 162, null, null, null, null, "NHL1949" );
            DataService.AddSeason(context, nhlId, 1950, 30, 162, null, null, null, null, "NHL1950" );
            DataService.AddSeason(context, nhlId, 1951, 30, 162, null, null, null, null, "NHL1951" );
            DataService.AddSeason(context, nhlId, 1952, 30, 162, null, null, null, null, "NHL1952" );
            DataService.AddSeason(context, nhlId, 1953, 30, 162, null, null, null, null, "NHL1953" );
            DataService.AddSeason(context, nhlId, 1954, 30, 162, null, null, null, null, "NHL1954" );
            DataService.AddSeason(context, nhlId, 1955, 30, 162, null, null, null, null, "NHL1955" );
            DataService.AddSeason(context, nhlId, 1956, 30, 162, null, null, null, null, "NHL1956" );
            DataService.AddSeason(context, nhlId, 1957, 30, 162, null, null, null, null, "NHL1957" );
            DataService.AddSeason(context, nhlId, 1958, 30, 162, null, null, null, null, "NHL1958" );
            DataService.AddSeason(context, nhlId, 1959, 30, 162, null, null, null, null, "NHL1959" );
            DataService.AddSeason(context, nhlId, 1960, 30, 162, null, null, null, null, "NHL1960" );
            DataService.AddSeason(context, nhlId, 1961, 30, 162, null, null, null, null, "NHL1961" );
            DataService.AddSeason(context, nhlId, 1962, 30, 162, null, null, null, null, "NHL1962" );
            DataService.AddSeason(context, nhlId, 1963, 30, 162, null, null, null, null, "NHL1963" );
            DataService.AddSeason(context, nhlId, 1964, 30, 162, null, null, null, null, "NHL1964" );
            DataService.AddSeason(context, nhlId, 1965, 30, 162, null, null, null, null, "NHL1965" );
            DataService.AddSeason(context, nhlId, 1966, 30, 162, null, null, null, null, "NHL1966" );

            DataService.AddSeason(context, nhlId, 1967, 12, 74, null, null, null, null, "NHL1967" );
            DataService.AddSeason(context, nhlId, 1968, 12, 76, null, null, null, null, "NHL1968" );
            DataService.AddSeason(context, nhlId, 1969, 12, 76, null, null, null, null, "NHL1969" );
            DataService.AddSeason(context, nhlId, 1970, 14, 78, null, null, null, null, "NHL1970" );
            DataService.AddSeason(context, nhlId, 1971, 14, 78, null, null, null, null, "NHL1971" );
            DataService.AddSeason(context, nhlId, 1972, 14, 78, null, null, null, null, "NHL1972" );
            DataService.AddSeason(context, nhlId, 1973, 16, 78, null, null, null, null, "NHL1973" );
            DataService.AddSeason(context, nhlId, 1974, 18, 80, null, null, null, null, "NHL1974" );
            DataService.AddSeason(context, nhlId, 1975, 18, 80, null, null, null, null, "NHL1975" );
            DataService.AddSeason(context, nhlId, 1976, 18, 80, null, null, null, null, "NHL1976" );
            DataService.AddSeason(context, nhlId, 1977, 18, 80, null, null, null, null, "NHL1977" );
            DataService.AddSeason(context, nhlId, 1978, 17, 80, null, null, null, null, "NHL1978" );
            DataService.AddSeason(context, nhlId, 1979, 21, 80, null, null, null, null, "NHL1979" );
            DataService.AddSeason(context, nhlId, 1980, 21, 80, null, null, null, null, "NHL1980" );
            DataService.AddSeason(context, nhlId, 1981, 21, 80, null, null, null, null, "NHL1981" );
            DataService.AddSeason(context, nhlId, 1982, 21, 80, null, null, null, null, "NHL1982" );
            DataService.AddSeason(context, nhlId, 1983, 21, 80, null, null, null, null, "NHL1983" );
            DataService.AddSeason(context, nhlId, 1984, 21, 80, null, null, null, null, "NHL1984" );
            DataService.AddSeason(context, nhlId, 1985, 21, 80, null, null, null, null, "NHL1985" );
            DataService.AddSeason(context, nhlId, 1986, 21, 80, null, null, null, null, "NHL1986" );
            DataService.AddSeason(context, nhlId, 1987, 21, 80, null, null, null, null, "NHL1987" );
            DataService.AddSeason(context, nhlId, 1988, 21, 80, null, null, null, null, "NHL1988" );
            DataService.AddSeason(context, nhlId, 1989, 21, 80, null, null, null, null, "NHL1989" );
            DataService.AddSeason(context, nhlId, 1990, 21, 80, null, null, null, null, "NHL1990" );
            DataService.AddSeason(context, nhlId, 1991, 22, 80, null, null, null, null, "NHL1991" );
            DataService.AddSeason(context, nhlId, 1992, 24, 84, null, null, null, null, "NHL1992" );
            DataService.AddSeason(context, nhlId, 1993, 26, 84, null, null, null, null, "NHL1993" );
            DataService.AddSeason(context, nhlId, 1994, 26, 48, null, null, null, null, "NHL1994" );
            DataService.AddSeason(context, nhlId, 1995, 26, 82, null, null, null, null, "NHL1995" );
            DataService.AddSeason(context, nhlId, 1996, 26, 82, null, null, null, null, "NHL1996" );
            DataService.AddSeason(context, nhlId, 1997, 26, 82, null, null, null, null, "NHL1997" );
            DataService.AddSeason(context, nhlId, 1998, 27, 82, null, null, null, null, "NHL1998" );
            DataService.AddSeason(context, nhlId, 1999, 28, 82, null, null, null, null, "NHL1999" );
            DataService.AddSeason(context, nhlId, 2000, 30, 82, null, null, null, null, "NHL2000" );
            DataService.AddSeason(context, nhlId, 2001, 30, 82, null, null, null, null, "NHL2001" );
            DataService.AddSeason(context, nhlId, 2002, 30, 82, null, null, null, null, "NHL2002" );
            DataService.AddSeason(context, nhlId, 2003, 30, 82, null, null, null, null, "NHL2003" );
            DataService.AddSeason(context, nhlId, 2004, 30, 82, null, null, null, null, "NHL2004" );
            DataService.AddSeason(context, nhlId, 2005, 30, 82, null, null, null, null, "NHL2005" );
            DataService.AddSeason(context, nhlId, 2006, 30, 82, null, null, null, null, "NHL2006" );
            DataService.AddSeason(context, nhlId, 2007, 30, 82, null, null, null, null, "NHL2007" );
            DataService.AddSeason(context, nhlId, 2008, 30, 82, null, null, null, null, "NHL2008" );
            DataService.AddSeason(context, nhlId, 2009, 30, 82, null, null, null, null, "NHL2009" );
            DataService.AddSeason(context, nhlId, 2010, 30, 82, null, null, null, null, "NHL2010" );
            DataService.AddSeason(context, nhlId, 2011, 30, 82, null, null, null, null, "NHL2011" );
            DataService.AddSeason(context, nhlId, 2012, 30, 82, null, null, null, null, "NHL2012" );
            DataService.AddSeason(context, nhlId, 2013, 30, 82, null, null, null, null, "NHL2013" );
            DataService.AddSeason(context, nhlId, 2014, 30, 82, null, null, null, null, "NHL2014" );
            DataService.AddSeason(context, nhlId, 2015, 30, 82, null, null, null, null, "NHL2015" );
            DataService.AddSeason(context, nhlId, 2016, 30, 82, null, null, null, null, "NHL2016" );
            DataService.AddSeason(context, nhlId, 2017, 31, 82, null, null, null, null, "NHL2017" );
            DataService.AddSeason(context, nhlId, 2018, 31, 82, null, null, null, null, "NHL2018" );
            DataService.AddSeason(context, nhlId, 2019, 31, 82, null, null, null, null, "NHL2019" );


        }
        private static void SeedTeams(M42Context context)
        {

        }
    }
}