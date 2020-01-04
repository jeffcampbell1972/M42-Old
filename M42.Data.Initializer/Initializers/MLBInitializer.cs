using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public static class MLBInitializer 
    {
        public static void Seed(M42Context m42)
        {
            SeedLeagues(m42);
            SeedConferences(m42);
            SeedDivisions(m42);
            SeedPositions(m42);
            SeedStatistics(m42);
            SeedFranchises(m42);
            SeedSeasons(m42);
            SeedTeams(m42);
            SeedHOF(m42);
        }
        private static void SeedLeagues(M42Context context)
        {
            int cooperstownId = context.HOFs.Include(x => x.Organization).Single(x => x.Organization.Identifier == "Cooperstown").Id;

            DataService.AddLeague(context, "MLB", "Major League Baseball", "MLB", Sport.Baseball.Id, cooperstownId, 1903);
            DataService.AddLeague(context, "NL", "National League", "NL", Sport.Baseball.Id, cooperstownId, 1876, 1902);
            DataService.AddLeague(context, "AL", "American League", "AL", Sport.Baseball.Id, cooperstownId, 1901, 1902);

            context.SaveChanges();
        }
        private static void SeedConferences(M42Context context)
        {
            int mlbId = context.Leagues.Include("Organization").Single(x => x.Organization.Identifier == "MLB").Id;

            DataService.AddConference(context, "NL", mlbId, "National League", 1);
            DataService.AddConference(context, "AL", mlbId, "American League", 2);

            context.SaveChanges();
        }
        private static void SeedDivisions(M42Context context)
        {
            int nlId = context.Conferences.Single(x => x.Identifier == "NL").Id;
            int alId = context.Conferences.Single(x => x.Identifier == "AL").Id;
        }
        private static void SeedPositions(M42Context context)
        {
            DataService.AddPosition(context, "Baseball-P", "Pitcher", "P", Sport.Baseball.Id, 1);
            DataService.AddPosition(context, "Baseball-C", "Catcher", "C", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-1B", "First Baseman", "1B", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-2B", "Second Baseman", "2B", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-3B", "Third Baseman", "3B", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-SS", "Shortstop", "SS", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-OF", "Outfielder", "OF", Sport.Baseball.Id, 1 );
            DataService.AddPosition(context, "Baseball-DH", "Designated Hitter", "DH", Sport.Baseball.Id, 1 );
        }
        private static void SeedStatistics(M42Context context)
        {

        }
        private static void SeedFranchises(M42Context context)
        {
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Washington Nationals", true , "MLB-Nationals" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "New York Mets", true , "MLB-Mets" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Atlanta Braves", true , "MLB-Braves" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Miami Marlins", true , "MLB-Marlins" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Philadelphia Phillies", true , "MLB-Phillies" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "St Louis Cardinals", true , "MLB-Cardinals" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Chicago Cubs", true , "MLB-Cubs" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Milwaukee Brewers", true , "MLB-Brewers" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Pittsburgh Pirates", true , "MLB-Pirates" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Cincinnati Reds", true , "MLB-Reds" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Los Angeles Dodgers", true , "MLB-Dodgers" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Arizona Diamondbacks", true , "MLB-Diamondbacks" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Colorado Rockies", true , "MLB-Rockies" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "San Francisco Giants", true , "MLB-Giants" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "San Diego Padres", true , "MLB-Padres" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Boston Red Sox", true , "MLB-RedSox" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "New York Yankees", true , "MLB-Yankees" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Baltimore Orioles", true , "MLB-Orioles" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Toronto Blue Jays", true , "MLB-BlueJays" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Tampa Bay Rays", true , "MLB-Rays" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Detroit Tigers", true , "MLB-Tigers" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Chicago White Sox", true , "MLB-WhiteSox" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Cleveland Indians", true , "MLB-Indians" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Kansas City Royals", true , "MLB-Royals" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Minnesota Twins", true , "MLB-Twins" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Oakland Athletics", true , "MLB-As" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "California Angels", true , "MLB-Angels" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Houston Astros", true , "MLB-Astros" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Texas Rangers", true , "MLB-Rangers" );
            DataService.AddFranchise(context, Sport.Baseball.Id, true, "Seattle Mariners", true , "MLB-Mariners" );

            context.SaveChanges();
        }
        private static void SeedSeasons(M42Context context)
        {
            int mlbId = context.Leagues.Single(x => x.Abbreviation == "MLB").Id;

            DataService.AddSeason(context, mlbId, 1903, 30, 154, null, null, null, null, "MLB1903" );
            DataService.AddSeason(context, mlbId, 1904, 30, 162, null, null, null, null, "MLB1904" );
            DataService.AddSeason(context, mlbId, 1905, 30, 162, null, null, null, null, "MLB1905" );
            DataService.AddSeason(context, mlbId, 1906, 30, 162, null, null, null, null, "MLB1906" );
            DataService.AddSeason(context, mlbId, 1907, 30, 162, null, null, null, null, "MLB1907" );
            DataService.AddSeason(context, mlbId, 1908, 30, 162, null, null, null, null, "MLB1908" );
            DataService.AddSeason(context, mlbId, 1909, 30, 162, null, null, null, null, "MLB1909" );
            DataService.AddSeason(context, mlbId, 1910, 30, 162, null, null, null, null, "MLB1910" );
            DataService.AddSeason(context, mlbId, 1911, 30, 162, null, null, null, null, "MLB1911" );
            DataService.AddSeason(context, mlbId, 1912, 30, 162, null, null, null, null, "MLB1912" );
            DataService.AddSeason(context, mlbId, 1913, 30, 162, null, null, null, null, "MLB1913" );
            DataService.AddSeason(context, mlbId, 1914, 30, 162, null, null, null, null, "MLB1914" );
            DataService.AddSeason(context, mlbId, 1915, 30, 162, null, null, null, null, "MLB1915" );
            DataService.AddSeason(context, mlbId, 1916, 30, 162, null, null, null, null, "MLB1916" );
            DataService.AddSeason(context, mlbId, 1917, 30, 162, null, null, null, null, "MLB1917" );
            DataService.AddSeason(context, mlbId, 1918, 30, 162, null, null, null, null, "MLB1918" );
            DataService.AddSeason(context, mlbId, 1919, 30, 162, null, null, null, null, "MLB1919" );
            DataService.AddSeason(context, mlbId, 1920, 30, 162, null, null, null, null, "MLB1920" );
            DataService.AddSeason(context, mlbId, 1921, 30, 162, null, null, null, null, "MLB1921" );
            DataService.AddSeason(context, mlbId, 1922, 30, 162, null, null, null, null, "MLB1922" );
            DataService.AddSeason(context, mlbId, 1923, 30, 162, null, null, null, null, "MLB1923" );
            DataService.AddSeason(context, mlbId, 1924, 30, 162, null, null, null, null, "MLB1924" );
            DataService.AddSeason(context, mlbId, 1925, 30, 162, null, null, null, null, "MLB1925" );
            DataService.AddSeason(context, mlbId, 1926, 30, 162, null, null, null, null, "MLB1926" );
            DataService.AddSeason(context, mlbId, 1927, 30, 162, null, null, null, null, "MLB1927" );
            DataService.AddSeason(context, mlbId, 1928, 30, 162, null, null, null, null, "MLB1928" );
            DataService.AddSeason(context, mlbId, 1929, 30, 162, null, null, null, null, "MLB1929" );
            DataService.AddSeason(context, mlbId, 1930, 30, 162, null, null, null, null, "MLB1930" );
            DataService.AddSeason(context, mlbId, 1931, 30, 162, null, null, null, null, "MLB1932" );
            DataService.AddSeason(context, mlbId, 1932, 30, 162, null, null, null, null, "MLB1932" );
            DataService.AddSeason(context, mlbId, 1933, 30, 162, null, null, null, null, "MLB1933" );
            DataService.AddSeason(context, mlbId, 1934, 30, 162, null, null, null, null, "MLB1934" );
            DataService.AddSeason(context, mlbId, 1935, 30, 162, null, null, null, null, "MLB1935" );
            DataService.AddSeason(context, mlbId, 1936, 30, 162, null, null, null, null, "MLB1936" );
            DataService.AddSeason(context, mlbId, 1937, 30, 162, null, null, null, null, "MLB1937" );
            DataService.AddSeason(context, mlbId, 1938, 30, 162, null, null, null, null, "MLB1938" );
            DataService.AddSeason(context, mlbId, 1939, 30, 162, null, null, null, null, "MLB1939" );
            DataService.AddSeason(context, mlbId, 1940, 30, 162, null, null, null, null, "MLB1940" );
            DataService.AddSeason(context, mlbId, 1941, 30, 162, null, null, null, null, "MLB1941" );
            DataService.AddSeason(context, mlbId, 1942, 30, 162, null, null, null, null, "MLB1942" );
            DataService.AddSeason(context, mlbId, 1943, 30, 162, null, null, null, null, "MLB1943" );
            DataService.AddSeason(context, mlbId, 1944, 30, 162, null, null, null, null, "MLB1944" );
            DataService.AddSeason(context, mlbId, 1945, 30, 162, null, null, null, null, "MLB1945" );
            DataService.AddSeason(context, mlbId, 1946, 30, 162, null, null, null, null, "MLB1946" );
            DataService.AddSeason(context, mlbId, 1947, 30, 162, null, null, null, null, "MLB1947" );
            DataService.AddSeason(context, mlbId, 1948, 30, 162, null, null, null, null, "MLB1948" );
            DataService.AddSeason(context, mlbId, 1949, 30, 162, null, null, null, null, "MLB1949" );
            DataService.AddSeason(context, mlbId, 1950, 30, 162, null, null, null, null, "MLB1950" );
            DataService.AddSeason(context, mlbId, 1951, 30, 162, null, null, null, null, "MLB1951" );
            DataService.AddSeason(context, mlbId, 1952, 30, 162, null, null, null, null, "MLB1952" );
            DataService.AddSeason(context, mlbId, 1953, 30, 162, null, null, null, null, "MLB1953" );
            DataService.AddSeason(context, mlbId, 1954, 30, 162, null, null, null, null, "MLB1954" );
            DataService.AddSeason(context, mlbId, 1955, 30, 162, null, null, null, null, "MLB1955" );
            DataService.AddSeason(context, mlbId, 1956, 30, 162, null, null, null, null, "MLB1956" );
            DataService.AddSeason(context, mlbId, 1957, 30, 162, null, null, null, null, "MLB1957" );
            DataService.AddSeason(context, mlbId, 1958, 30, 162, null, null, null, null, "MLB1958" );
            DataService.AddSeason(context, mlbId, 1959, 30, 162, null, null, null, null, "MLB1959" );
            DataService.AddSeason(context, mlbId, 1960, 30, 162, null, null, null, null, "MLB1960" );
            DataService.AddSeason(context, mlbId, 1961, 30, 162, null, null, null, null, "MLB1961" );
            DataService.AddSeason(context, mlbId, 1962, 30, 162, null, null, null, null, "MLB1962" );
            DataService.AddSeason(context, mlbId, 1963, 30, 162, null, null, null, null, "MLB1963" );
            DataService.AddSeason(context, mlbId, 1964, 30, 162, null, null, null, null, "MLB1964" );
            DataService.AddSeason(context, mlbId, 1965, 30, 162, null, null, null, null, "MLB1965" );
            DataService.AddSeason(context, mlbId, 1966, 30, 162, null, null, null, null, "MLB1966" );
            DataService.AddSeason(context, mlbId, 1967, 30, 162, null, null, null, null, "MLB1967" );
            DataService.AddSeason(context, mlbId, 1968, 30, 162, null, null, null, null, "MLB1968" );
            DataService.AddSeason(context, mlbId, 1969, 30, 162, null, null, null, null, "MLB1969" );
            DataService.AddSeason(context, mlbId, 1970, 30, 162, null, null, null, null, "MLB1970" );
            DataService.AddSeason(context, mlbId, 1971, 30, 162, null, null, null, null, "MLB1971" );
            DataService.AddSeason(context, mlbId, 1972, 30, 162, null, null, null, null, "MLB1972" );
            DataService.AddSeason(context, mlbId, 1973, 30, 162, null, null, null, null, "MLB1973" );
            DataService.AddSeason(context, mlbId, 1974, 30, 162, null, null, null, null, "MLB1974" );
            DataService.AddSeason(context, mlbId, 1975, 30, 162, null, null, null, null, "MLB1975" );
            DataService.AddSeason(context, mlbId, 1976, 30, 162, null, null, null, null, "MLB1976" );
            DataService.AddSeason(context, mlbId, 1977, 30, 162, null, null, null, null, "MLB1977" );
            DataService.AddSeason(context, mlbId, 1978, 30, 162, null, null, null, null, "MLB1978" );
            DataService.AddSeason(context, mlbId, 1979, 30, 162, null, null, null, null, "MLB1979" );
            DataService.AddSeason(context, mlbId, 1980, 30, 162, null, null, null, null, "MLB1980" );
            DataService.AddSeason(context, mlbId, 1981, 30, 162, null, null, null, null, "MLB1981" );
            DataService.AddSeason(context, mlbId, 1982, 30, 162, null, null, null, null, "MLB1982" );
            DataService.AddSeason(context, mlbId, 1983, 30, 162, null, null, null, null, "MLB1983" );
            DataService.AddSeason(context, mlbId, 1984, 30, 162, null, null, null, null, "MLB1984" );
            DataService.AddSeason(context, mlbId, 1985, 30, 162, null, null, null, null, "MLB1985" );
            DataService.AddSeason(context, mlbId, 1986, 30, 162, null, null, null, null, "MLB1986" );
            DataService.AddSeason(context, mlbId, 1987, 30, 162, null, null, null, null, "MLB1987" );
            DataService.AddSeason(context, mlbId, 1988, 30, 162, null, null, null, null, "MLB1988" );
            DataService.AddSeason(context, mlbId, 1989, 30, 162, null, null, null, null, "MLB1989" );
            DataService.AddSeason(context, mlbId, 1990, 30, 162, null, null, null, null, "MLB1990" );
            DataService.AddSeason(context, mlbId, 1991, 30, 162, null, null, null, null, "MLB1991" );
            DataService.AddSeason(context, mlbId, 1992, 30, 162, null, null, null, null, "MLB1992" );
            DataService.AddSeason(context, mlbId, 1993, 30, 162, null, null, null, null, "MLB1993" );
            DataService.AddSeason(context, mlbId, 1994, 30, 162, null, null, null, null, "MLB1994" );
            DataService.AddSeason(context, mlbId, 1995, 30, 162, null, null, null, null, "MLB1995" );
            DataService.AddSeason(context, mlbId, 1996, 30, 162, null, null, null, null, "MLB1996" );
            DataService.AddSeason(context, mlbId, 1997, 30, 162, null, null, null, null, "MLB1997" );
            DataService.AddSeason(context, mlbId, 1998, 30, 162, null, null, null, null, "MLB1998" );
            DataService.AddSeason(context, mlbId, 1999, 30, 162, null, null, null, null, "MLB1999" );
            DataService.AddSeason(context, mlbId, 2000, 30, 162, null, null, null, null, "MLB2000" );
            DataService.AddSeason(context, mlbId, 2001, 30, 162, null, null, null, null, "MLB2001" );
            DataService.AddSeason(context, mlbId, 2002, 30, 162, null, null, null, null, "MLB2002" );
            DataService.AddSeason(context, mlbId, 2003, 30, 162, null, null, null, null, "MLB2003" );
            DataService.AddSeason(context, mlbId, 2004, 30, 162, null, null, null, null, "MLB2004" );
            DataService.AddSeason(context, mlbId, 2005, 30, 162, null, null, null, null, "MLB2005" );
            DataService.AddSeason(context, mlbId, 2006, 30, 162, null, null, null, null, "MLB2006" );
            DataService.AddSeason(context, mlbId, 2007, 30, 162, null, null, null, null, "MLB2007" );
            DataService.AddSeason(context, mlbId, 2008, 30, 162, null, null, null, null, "MLB2008" );
            DataService.AddSeason(context, mlbId, 2009, 30, 162, null, null, null, null, "MLB2009" );
            DataService.AddSeason(context, mlbId, 2010, 30, 162, null, null, null, null, "MLB2010" );
            DataService.AddSeason(context, mlbId, 2011, 30, 162, null, null, null, null, "MLB2011" );
            DataService.AddSeason(context, mlbId, 2012, 30, 162, null, null, null, null, "MLB2012" );
            DataService.AddSeason(context, mlbId, 2013, 30, 162, null, null, null, null, "MLB2013" );
            DataService.AddSeason(context, mlbId, 2014, 30, 162, null, null, null, null, "MLB2014" );
            DataService.AddSeason(context, mlbId, 2015, 30, 162, null, null, null, null, "MLB2015" );
            DataService.AddSeason(context, mlbId, 2016, 30, 162, null, null, null, null, "MLB2016" );
            DataService.AddSeason(context, mlbId, 2017, 30, 162, null, null, null, null, "MLB2017" );
            DataService.AddSeason(context, mlbId, 2018, 30, 162, null, null, null, null, "MLB2018" );
            DataService.AddSeason(context, mlbId, 2019, 30, 162, null, null, null, null, "MLB2019" );


        }
        private static void SeedTeams(M42Context context)
        {

        }
        private static void SeedHOF(M42Context context)
        {
            int hofId = context.Organizations.Single(x => x.Identifier == "Cooperstown").Id;
            string hofFilename = System.IO.Path.Combine(Constants.MLBFolder, "HallOfFamers.csv");

            string[] lines = File.ReadAllLines(hofFilename);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                string personIdentifier = values[0];
                int yearInducted = Convert.ToInt32(values[1]);

                DataService.AddHofer(context, personIdentifier, hofId, yearInducted);
            }
        }

    }
}