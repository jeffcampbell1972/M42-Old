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
    public static class NFLInitializer
    {
        public static void Seed(M42Context m42)
        {
            SeedLeagues(m42);
            SeedConferences(m42);
            SeedDivisions(m42);
            SeedFranchises(m42);
            SeedSeasons(m42);
            SeedAFLSeasons(m42);
            SeedTeams(m42);
            SeedTeamPlayers(m42);
            SeedDrafts(m42);
            SeedRegularSeasons(m42);
            SeedPlayoffs(m42);
            SeedMVPs(m42);
            SeedROYs(m42);
            SeedHOF(m42);
        }

        private static void SeedLeagues(M42Context context)
        {
            int cantonId = context.HOFs.Include(x => x.Organization).Single(x => x.Organization.Identifier == "Canton").Id;

            DataService.AddLeague(context, "NFL", "National Football League", "NFL", Sport.Football.Id, cantonId, 1920);
            DataService.AddLeague(context, "CFL", "Canadian Football League", "CFL", Sport.Football.Id, cantonId, 1958);
            DataService.AddLeague(context, "AFL", "American Football League", "AFL", Sport.Football.Id, cantonId, 1960, 1969);
            DataService.AddLeague(context, "AAFC", "All-America Football Conference", "AAFC", Sport.Football.Id, cantonId, 1946, 1949);
            DataService.AddLeague(context, "WFL", "World Football League", "WFL", Sport.Football.Id, cantonId, 1974, 1975);
            DataService.AddLeague(context, "USFL", "United States Football League", "USFL", Sport.Football.Id, cantonId, 1983, 1984);

            context.SaveChanges();
        }
        private static void SeedConferences(M42Context context)
        {
            int nflId = context.Leagues.Include("Organization").Single(x => x.Organization.Identifier == "NFL").Id;
            int aflId = context.Leagues.Include("Organization").Single(x => x.Organization.Identifier == "AFL").Id;

            DataService.AddConference(context, "NFC", nflId, "National Football Conference", 1 );
            DataService.AddConference(context, "AFC", nflId, "American Football Conference", 2 );
            DataService.AddConference(context, "NFLAmerican", nflId, "American", 1 );
            DataService.AddConference(context, "NFLNational", nflId, "National", 2 );
            DataService.AddConference(context, "NFLEastern", nflId, "Eastern", 1 );
            DataService.AddConference(context, "NFLWestern", nflId, "Western", 2 );

            DataService.AddConference(context, "AFLEastern", aflId, "Eastern", 2 );
            DataService.AddConference(context, "AFLWestern", aflId, "Western", 2 );

            context.SaveChanges();
        }
        private static void SeedDivisions(M42Context context)
        {
            int nfleId = context.Conferences.Single(x => x.Identifier == "NFLEastern").Id;
            int nflwId = context.Conferences.Single(x => x.Identifier == "NFLWestern").Id;
            int nfcId = context.Conferences.Single(x => x.Identifier == "NFC").Id;
            int afcId = context.Conferences.Single(x => x.Identifier == "AFC").Id;

            DataService.AddDivision(context, "NFLCapital", "Capital", nfleId, 1, 1967, 1969);
            DataService.AddDivision(context, "NFLCentury", "Century", nfleId, 2, 1967, 1969);
            DataService.AddDivision(context, "NFLCoastal", "Coastal", nflwId, 1, 1967, 1969);
            DataService.AddDivision(context, "NFLCentral", "Central", nflwId, 2, 1967, 1969);

            DataService.AddDivision(context, "NFCEast", "East", nfcId, 1, 1967, 1969);
            DataService.AddDivision(context, "NFCWest", "West", nfcId, 4, 1967, 1969);
            DataService.AddDivision(context, "NFCCentral", "Central", nfcId, 2, 1967, 1969);
            DataService.AddDivision(context, "NFCNorth", "North", nfcId, 2, 1967, 1969);
            DataService.AddDivision(context, "NFCSouth", "South", nfcId, 3, 1967, 1969);
            DataService.AddDivision(context, "AFCEast", "East", afcId, 5, 1967, 1969);
            DataService.AddDivision(context, "AFCWest", "West", afcId, 8, 1967, 1969);
            DataService.AddDivision(context, "AFCCentral", "Central", afcId, 6, 1967, 1969);
            DataService.AddDivision(context, "AFCNorth", "North", afcId, 6, 1967, 1969);
            DataService.AddDivision(context, "AFCSouth", "South", afcId, 7, 1967, 1969);
        }
        private static void SeedHOF(M42Context context)
        {
            int hofId = context.Organizations.Single(x => x.Identifier == "Canton").Id;
            string hofFilename = System.IO.Path.Combine(Constants.NFLFolder, "Pro Football Hall of Fame.csv");

            string[] lines = File.ReadAllLines(hofFilename);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                string personIdentifier = values[0];
                int yearInducted = Convert.ToInt32(values[1]);

                DataService.AddHofer(context, personIdentifier, hofId, yearInducted);
            }
        }
        private static void SeedFranchises(M42Context context)
        {
            DataService.AddFranchise(context, Sport.Football.Id, true, "Washington Redskins", true, "NFL-Redskins"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Dallas Cowboys", true, "NFL-Cowboys"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "New York Giants", true, "NFL-Giants"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Philadelphia Eagles", true, "NFL-Eagles"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Green Bay Packers", true, "NFL-Packers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Minnesota Vikings", true, "NFL-Vikings"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Detroit Lions", true, "NFL-Lions"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Chicago Bears", true, "NFL-Bears"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Carolina Panthers", true, "NFL-Panthers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "New Orleans Saints", true, "NFL-Saints"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Atlanta Falcons", true, "NFL-Falcons"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Tampa Bay Buccaneers", true, "NFL-Buccaneers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Arizona Cardinals", true, "NFL-Cardinals"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "San Francisco 49ers", true, "NFL-49ers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Seattle Seahawks", true, "NFL-Seahawks"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Los Angeles Rams", true, "NFL-Rams"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "New England Patriots", true, "NFL-Patriots"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "New York Jets", true, "NFL-Jets"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Buffalo Bills", true, "NFL-Bills"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Miami Dolphins", true, "NFL-Dolphins"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Tennessee Titans", true, "NFL-Titans"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Houston Texans", true, "NFL-Texans"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Indianapolis Colts", true, "NFL-Colts"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "JacksonvilleJaguars", true, "NFL-Jaguars"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "San Diego Chargers", true, "NFL-Chargers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Kansas City Chiefs", true, "NFL-Chiefs"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Oakland Raiders", true, "NFL-Raiders"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Denver Broncos", true, "NFL-Broncos"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Cleveland Browns", true, "NFL-Browns"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Cincinnati Bengals", true, "NFL-Bengals"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Pittsburgh Steelers", true, "NFL-Steelers"  );
            DataService.AddFranchise(context, Sport.Football.Id, true, "Baltimore Ravens", true, "NFL-Ravens"  );

            context.SaveChanges();
        }
        private static void SeedSeasons(M42Context context)
        {
            int nflId = context.Leagues.Single(x => x.Abbreviation == "NFL").Id;
            int jimThorpeId = context.People.Single(x => x.Identifier == "JimThorpe").Id;
            int josehpCarrId = context.People.Single(x => x.Identifier == "JoeCarr").Id;
            int carlStockId = context.People.Single(x => x.Identifier == "CarlStork").Id;
            int elmerLaydenId = context.People.Single(x => x.Identifier == "ElmerLayden").Id;
            int bertBellId = context.People.Single(x => x.Identifier == "BertBell").Id;
            int austinGunselId = context.People.Single(x => x.Identifier == "AustinGunsel").Id;
            int peteRozelleId = context.People.Single(x => x.Identifier == "PeteRozelle").Id;
            int paulTagliabueId = context.People.Single(x => x.Identifier == "PaulTagliabue").Id;
            int rogerGoodellId = context.People.Single(x => x.Identifier == "RogerGoodell").Id;

            DataService.AddSeason(context, nflId, 1920, 12, 12, "American Professional Football Association", "APFA", jimThorpeId, null, "NFL1920" );
            DataService.AddSeason(context, nflId, 1921, 12, 12, "American Professional Football Association", "APFA", josehpCarrId, null, "NFL1921" );
            DataService.AddSeason(context, nflId, 1922, 12, 12, null, null, josehpCarrId, null, "NFL1922" );
            DataService.AddSeason(context, nflId, 1923, 12, 12, null, null, josehpCarrId, null, "NFL1923" );
            DataService.AddSeason(context, nflId, 1924, 12, 12, null, null, josehpCarrId, null, "NFL1924" );
            DataService.AddSeason(context, nflId, 1925, 12, 12, null, null, josehpCarrId, null, "NFL1925" );
            DataService.AddSeason(context, nflId, 1926, 12, 12, null, null, josehpCarrId, null, "NFL1926" );
            DataService.AddSeason(context, nflId, 1927, 12, 12, null, null, josehpCarrId, null, "NFL1927" );
            DataService.AddSeason(context, nflId, 1928, 12, 12, null, null, josehpCarrId, null, "NFL1928" );
            DataService.AddSeason(context, nflId, 1929, 12, 12, null, null, josehpCarrId, null, "NFL1929" );
            DataService.AddSeason(context, nflId, 1930, 12, 12, null, null, josehpCarrId, null, "NFL1930" );
            DataService.AddSeason(context, nflId, 1931, 12, 12, null, null, josehpCarrId, null, "NFL1931" );
            DataService.AddSeason(context, nflId, 1932, 12, 12, null, null, josehpCarrId, null, "NFL1932" );
            DataService.AddSeason(context, nflId, 1933, 12, 12, null, null, josehpCarrId, null, "NFL1933" );
            DataService.AddSeason(context, nflId, 1934, 12, 12, null, null, josehpCarrId, null, "NFL1934" );
            DataService.AddSeason(context, nflId, 1935, 12, 12, null, null, josehpCarrId, null, "NFL1935" );
            DataService.AddSeason(context, nflId, 1936, 12, 12, null, null, josehpCarrId, null, "NFL1936" );
            DataService.AddSeason(context, nflId, 1937, 12, 12, null, null, josehpCarrId, null, "NFL1937" );
            DataService.AddSeason(context, nflId, 1938, 12, 12, null, null, josehpCarrId, null, "NFL1938" );
            DataService.AddSeason(context, nflId, 1939, 12, 12, null, null, carlStockId, null, "NFL1939" );
            DataService.AddSeason(context, nflId, 1940, 12, 12, null, null, carlStockId, null, "NFL1940" );
            DataService.AddSeason(context, nflId, 1941, 12, 12, null, null, null, elmerLaydenId, "NFL1941" );
            DataService.AddSeason(context, nflId, 1942, 12, 12, null, null, null, elmerLaydenId, "NFL1942" );
            DataService.AddSeason(context, nflId, 1943, 12, 12, null, null, null, elmerLaydenId, "NFL1943" );
            DataService.AddSeason(context, nflId, 1944, 12, 12, null, null, null, elmerLaydenId, "NFL1944" );
            DataService.AddSeason(context, nflId, 1945, 12, 12, null, null, null, elmerLaydenId, "NFL1945" );
            DataService.AddSeason(context, nflId, 1946, 12, 12, null, null, null, bertBellId, "NFL1946" );
            DataService.AddSeason(context, nflId, 1947, 12, 12, null, null, null, bertBellId, "NFL1947" );
            DataService.AddSeason(context, nflId, 1948, 12, 12, null, null, null, bertBellId, "NFL1948" );
            DataService.AddSeason(context, nflId, 1949, 12, 12, null, null, null, bertBellId, "NFL1949" );
            DataService.AddSeason(context, nflId, 1950, 12, 12, null, null, null, bertBellId, "NFL1950" );
            DataService.AddSeason(context, nflId, 1951, 12, 12, null, null, null, bertBellId, "NFL1951" );
            DataService.AddSeason(context, nflId, 1952, 12, 12, null, null, null, bertBellId, "NFL1952" );
            DataService.AddSeason(context, nflId, 1953, 12, 12, null, null, null, bertBellId, "NFL1953" );
            DataService.AddSeason(context, nflId, 1954, 12, 12, null, null, null, bertBellId, "NFL1954" );
            DataService.AddSeason(context, nflId, 1955, 12, 12, null, null, null, bertBellId, "NFL1955" );
            DataService.AddSeason(context, nflId, 1956, 12, 12, null, null, null, bertBellId, "NFL1956" );
            DataService.AddSeason(context, nflId, 1957, 12, 12, null, null, null, bertBellId, "NFL1957" );
            DataService.AddSeason(context, nflId, 1958, 12, 12, null, null, null, bertBellId, "NFL1958" );
            DataService.AddSeason(context, nflId, 1959, 12, 12, null, null, null, austinGunselId, "NFL1959" );
            DataService.AddSeason(context, nflId, 1960, 13, 12, null, null, null, peteRozelleId, "NFL1960" );
            DataService.AddSeason(context, nflId, 1961, 14, 14, null, null, null, peteRozelleId, "NFL1961" );
            DataService.AddSeason(context, nflId, 1962, 14, 14, null, null, null, peteRozelleId, "NFL1962" );
            DataService.AddSeason(context, nflId, 1963, 14, 14, null, null, null, peteRozelleId, "NFL1963" );
            DataService.AddSeason(context, nflId, 1964, 14, 14, null, null, null, peteRozelleId, "NFL1964" );
            DataService.AddSeason(context, nflId, 1965, 14, 14, null, null, null, peteRozelleId, "NFL1965" );
            DataService.AddSeason(context, nflId, 1966, 15, 14, null, null, null, peteRozelleId, "NFL1966" );
            DataService.AddSeason(context, nflId, 1967, 16, 14, null, null, null, peteRozelleId, "NFL1967" );
            DataService.AddSeason(context, nflId, 1968, 16, 14, null, null, null, peteRozelleId, "NFL1968" );
            DataService.AddSeason(context, nflId, 1969, 16, 14, null, null, null, peteRozelleId, "NFL1969" );
            DataService.AddSeason(context, nflId, 1970, 26, 14, null, null, null, peteRozelleId, "NFL1970" );
            DataService.AddSeason(context, nflId, 1971, 26, 14, null, null, null, peteRozelleId, "NFL1971" );
            DataService.AddSeason(context, nflId, 1972, 26, 14, null, null, null, peteRozelleId, "NFL1972" );
            DataService.AddSeason(context, nflId, 1973, 26, 14, null, null, null, peteRozelleId, "NFL1973" );
            DataService.AddSeason(context, nflId, 1974, 26, 14, null, null, null, peteRozelleId, "NFL1974" );
            DataService.AddSeason(context, nflId, 1975, 26, 14, null, null, null, peteRozelleId, "NFL1975" );
            DataService.AddSeason(context, nflId, 1976, 28, 14, null, null, null, peteRozelleId, "NFL1976" );
            DataService.AddSeason(context, nflId, 1977, 28, 14, null, null, null, peteRozelleId, "NFL1977" );
            DataService.AddSeason(context, nflId, 1978, 28, 14, null, null, null, peteRozelleId, "NFL1978" );
            DataService.AddSeason(context, nflId, 1979, 28, 14, null, null, null, peteRozelleId, "NFL1979" );
            DataService.AddSeason(context, nflId, 1980, 28, 14, null, null, null, peteRozelleId, "NFL1980" );
            DataService.AddSeason(context, nflId, 1981, 28, 14, null, null, null, peteRozelleId, "NFL1981" );
            DataService.AddSeason(context, nflId, 1982, 28, 9, null, null, null, peteRozelleId, "NFL1982" );
            DataService.AddSeason(context, nflId, 1983, 28, 16, null, null, null, peteRozelleId, "NFL1983" );
            DataService.AddSeason(context, nflId, 1984, 28, 16, null, null, null, peteRozelleId, "NFL1984" );
            DataService.AddSeason(context, nflId, 1985, 28, 16, null, null, null, peteRozelleId, "NFL1985" );
            DataService.AddSeason(context, nflId, 1986, 28, 16, null, null, null, peteRozelleId, "NFL1986" );
            DataService.AddSeason(context, nflId, 1987, 28, 16, null, null, null, peteRozelleId, "NFL1987" );
            DataService.AddSeason(context, nflId, 1988, 28, 16, null, null, null, peteRozelleId, "NFL1988" );
            DataService.AddSeason(context, nflId, 1989, 28, 16, null, null, null, paulTagliabueId, "NFL1989" );
            DataService.AddSeason(context, nflId, 1990, 28, 16, null, null, null, paulTagliabueId, "NFL1990" );
            DataService.AddSeason(context, nflId, 1991, 28, 16, null, null, null, paulTagliabueId, "NFL1991" );
            DataService.AddSeason(context, nflId, 1992, 28, 16, null, null, null, paulTagliabueId, "NFL1992" );
            DataService.AddSeason(context, nflId, 1993, 28, 16, null, null, null, paulTagliabueId, "NFL1993" );
            DataService.AddSeason(context, nflId, 1994, 28, 16, null, null, null, paulTagliabueId, "NFL1994" );
            DataService.AddSeason(context, nflId, 1995, 30, 16, null, null, null, paulTagliabueId, "NFL1995" );
            DataService.AddSeason(context, nflId, 1996, 30, 16, null, null, null, paulTagliabueId, "NFL1996" );
            DataService.AddSeason(context, nflId, 1997, 30, 16, null, null, null, paulTagliabueId, "NFL1997" );
            DataService.AddSeason(context, nflId, 1998, 30, 16, null, null, null, paulTagliabueId, "NFL1998" );
            DataService.AddSeason(context, nflId, 1999, 31, 16, null, null, null, paulTagliabueId, "NFL1999" );
            DataService.AddSeason(context, nflId, 2000, 31, 16, null, null, null, paulTagliabueId, "NFL2000" );
            DataService.AddSeason(context, nflId, 2001, 31, 16, null, null, null, paulTagliabueId, "NFL2001" );
            DataService.AddSeason(context, nflId, 2002, 32, 16, null, null, null, paulTagliabueId, "NFL2002" );
            DataService.AddSeason(context, nflId, 2003, 32, 16, null, null, null, paulTagliabueId, "NFL2003" );
            DataService.AddSeason(context, nflId, 2004, 32, 16, null, null, null, paulTagliabueId, "NFL2004" );
            DataService.AddSeason(context, nflId, 2005, 32, 16, null, null, null, paulTagliabueId, "NFL2005" );
            DataService.AddSeason(context, nflId, 2006, 32, 16, null, null, null, rogerGoodellId, "NFL2006" );
            DataService.AddSeason(context, nflId, 2007, 32, 16, null, null, null, rogerGoodellId, "NFL2007" );
            DataService.AddSeason(context, nflId, 2008, 32, 16, null, null, null, rogerGoodellId, "NFL2008" );
            DataService.AddSeason(context, nflId, 2009, 32, 16, null, null, null, rogerGoodellId, "NFL2009" );
            DataService.AddSeason(context, nflId, 2010, 32, 16, null, null, null, rogerGoodellId, "NFL2010" );
            DataService.AddSeason(context, nflId, 2011, 32, 16, null, null, null, rogerGoodellId, "NFL2011" );
            DataService.AddSeason(context, nflId, 2012, 32, 16, null, null, null, rogerGoodellId, "NFL2012" );
            DataService.AddSeason(context, nflId, 2013, 32, 16, null, null, null, rogerGoodellId, "NFL2013" );
            DataService.AddSeason(context, nflId, 2014, 32, 16, null, null, null, rogerGoodellId, "NFL2014" );
            DataService.AddSeason(context, nflId, 2015, 32, 16, null, null, null, rogerGoodellId, "NFL2015" );
            DataService.AddSeason(context, nflId, 2016, 32, 16, null, null, null, rogerGoodellId, "NFL2016" );
            DataService.AddSeason(context, nflId, 2017, 32, 16, null, null, null, rogerGoodellId, "NFL2017" );
            DataService.AddSeason(context, nflId, 2018, 32, 16, null, null, null, rogerGoodellId, "NFL2018" );
            DataService.AddSeason(context, nflId, 2019, 32, 16, null, null, null, rogerGoodellId, "NFL2019" );

            context.SaveChanges();
        }
        private static void SeedAFLSeasons(M42Context context)
        {
            int aflId = context.Leagues.Single(x => x.Abbreviation == "AFL").Id;

            DataService.AddSeason(context, aflId, 1960, 8, 14, null, null, null, null, "AFL1960");
            DataService.AddSeason(context, aflId, 1961, 8, 14, null, null, null, null, "AFL1961");
            DataService.AddSeason(context, aflId, 1962, 8, 14, null, null, null, null, "AFL1962");
            DataService.AddSeason(context, aflId, 1963, 8, 14, null, null, null, null, "AFL1963");
            DataService.AddSeason(context, aflId, 1964, 8, 14, null, null, null, null, "AFL1964");
            DataService.AddSeason(context, aflId, 1965, 8, 14, null, null, null, null, "AFL1965");
            DataService.AddSeason(context, aflId, 1966, 9, 14, null, null, null, null, "AFL1966");
            DataService.AddSeason(context, aflId, 1967, 9, 14, null, null, null, null, "AFL1967");
            DataService.AddSeason(context, aflId, 1968, 10, 14, null, null, null, null, "AFL1968");
            DataService.AddSeason(context, aflId, 1969, 10, 14, null, null, null, null, "AFL1969");

            context.SaveChanges();
        }
        private static void SeedTeams(M42Context context)
        {
            string scriptPath = Path.Combine(Constants.ScriptsFolder, "SeedNFLTeams.sql");
            SqlService.ExecuteSqlScript(context, scriptPath);
        }
        private static void SeedTeamPlayers(M42Context context)
        {
            string scriptPath = Path.Combine(Constants.ScriptsFolder, "SeedNFLTeamPlayers.sql");
            SqlService.ExecuteSqlScript(context, scriptPath);
        }
        private static void SeedDrafts(M42Context context)
        {
            string scriptPath = Path.Combine(Constants.ScriptsFolder, "SeedNFLDrafts.sql");
            SqlService.ExecuteSqlScript(context, scriptPath);
        }
        private static void SeedPlayoffs(M42Context context)
        {
            string playoffFilename = System.IO.Path.Combine(Constants.NFLFolder, "NFL Playoffs.csv");
            string[] lines = System.IO.File.ReadAllLines(playoffFilename);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                string year = values[0];
                string leagueIdentifier = values[1];
                string sortOrder = values[2];
                string gameTypeIdentifier = values[3];
                string gameTitle = values[4];
                string winner = values[5];
                int winningScore = Convert.ToInt32(values[6]);
                int losingScore = Convert.ToInt32(values[7]);
                string ot = values[8];
                string loser = values[9];
                string stadium = values[10];
                string attendence = values[11];
                string sbNumber = values[12];
                string date = values[13];
                string mvp = values[14];

                string xx = context.Teams.First().Identifier;

                string seasonIdentifier = "NFL" + year.ToString();
                string winningTeamIdentifier = year.ToString() + "-NFL-" + winner;
                string losingTeamIdentifier = year.ToString() + "-NFL-" + loser;

                var season = context.Seasons.SingleOrDefault(x => x.Identifier == seasonIdentifier);

                if (season == null)
                {
                    continue;
                }
                int gameTypeId = context.GameTypes.Single(x => x.Identifier == gameTypeIdentifier).Id;
                int winningTeamId = context.Teams.Single(x => x.Identifier == winningTeamIdentifier).Id;
                int losingTeamId = context.Teams.Single(x => x.Identifier == losingTeamIdentifier).Id;
                int? otCount = null;

                int? att = null;
                if (attendence != "") att = Convert.ToInt32(attendence);

                if (ot == "OT") otCount = 1;
                if (ot == "2OT") otCount = 2;

                context.Games.Add(new Game
                {
                    SeasonId = season.Id ,
                    GameTypeId = gameTypeId,
                    Title = gameTitle,
                    WinningTeamId = winningTeamId,
                    LosingTeamId = losingTeamId,
                    HomeTeamId = winningTeamId ,
                    AwayTeamId = losingTeamId ,
                    WinningScore = winningScore,
                    LosingScore = losingScore,
                    Attendence = att ,
                    Stadium = stadium,
                    OvertimeCount = otCount ,
                    SortOrder = Int32.Parse(sortOrder)
                });
                context.SaveChanges();
            }
        }
        private static void SeedMVPs(M42Context context)
        {
            int nflId = context.Leagues.Single(x => x.Abbreviation == "NFL").Id;

            DataService.AddSeasonAward(context, nflId, 1975, Award.MVP.Id, "FranTarkenton");
            DataService.AddSeasonAward(context, nflId, 1976, Award.MVP.Id, "BertJones");
            DataService.AddSeasonAward(context, nflId, 1977, Award.MVP.Id, "WalterPayton");
            DataService.AddSeasonAward(context, nflId, 1978, Award.MVP.Id, "EarlCampbell");
            DataService.AddSeasonAward(context, nflId, 1979, Award.MVP.Id, "EarlCampbell");
            DataService.AddSeasonAward(context, nflId, 1980, Award.MVP.Id, "BrianSipe");
            DataService.AddSeasonAward(context, nflId, 1981, Award.MVP.Id, "KenAnderson");
            DataService.AddSeasonAward(context, nflId, 1982, Award.MVP.Id, "DanFouts");
            DataService.AddSeasonAward(context, nflId, 1983, Award.MVP.Id, "JoeTheismann");
            DataService.AddSeasonAward(context, nflId, 1984, Award.MVP.Id, "DanMarino");
            DataService.AddSeasonAward(context, nflId, 1985, Award.MVP.Id, "MarcusAllen");
            DataService.AddSeasonAward(context, nflId, 1986, Award.MVP.Id, "LawrenceTaylor");
            DataService.AddSeasonAward(context, nflId, 1987, Award.MVP.Id, "JerryRice");
            DataService.AddSeasonAward(context, nflId, 1988, Award.MVP.Id, "BoomerEsiason");
            DataService.AddSeasonAward(context, nflId, 1989, Award.MVP.Id, "JoeMontana");
            DataService.AddSeasonAward(context, nflId, 1990, Award.MVP.Id, "JoeMontana");
            DataService.AddSeasonAward(context, nflId, 1991, Award.MVP.Id, "ThurmanThomas");
            DataService.AddSeasonAward(context, nflId, 1992, Award.MVP.Id, "SteveYoung");
            DataService.AddSeasonAward(context, nflId, 1993, Award.MVP.Id, "EmmittSmith");
            DataService.AddSeasonAward(context, nflId, 1994, Award.MVP.Id, "SteveYoung");
            DataService.AddSeasonAward(context, nflId, 1995, Award.MVP.Id, "BrettFavre");
            DataService.AddSeasonAward(context, nflId, 1996, Award.MVP.Id, "BrettFavre");
            DataService.AddSeasonAward(context, nflId, 1997, Award.MVP.Id, "BarrySanders");
            DataService.AddSeasonAward(context, nflId, 1997, Award.MVP.Id, "BrettFavre");
            DataService.AddSeasonAward(context, nflId, 1998, Award.MVP.Id, "TerrellDavis");
            DataService.AddSeasonAward(context, nflId, 1999, Award.MVP.Id, "KurtWarner");
            DataService.AddSeasonAward(context, nflId, 2000, Award.MVP.Id, "MarshallFaulk");
            DataService.AddSeasonAward(context, nflId, 2001, Award.MVP.Id, "KurtWarner");
            DataService.AddSeasonAward(context, nflId, 2002, Award.MVP.Id, "RichGannon");
            DataService.AddSeasonAward(context, nflId, 2003, Award.MVP.Id, "PeytonManning");
            DataService.AddSeasonAward(context, nflId, 2003, Award.MVP.Id, "SteveMcNair");
            DataService.AddSeasonAward(context, nflId, 2004, Award.MVP.Id, "PeytonManning");
            DataService.AddSeasonAward(context, nflId, 2005, Award.MVP.Id, "ShaunAlexander");
            DataService.AddSeasonAward(context, nflId, 2006, Award.MVP.Id, "LaDainianTomlinson");
            DataService.AddSeasonAward(context, nflId, 2007, Award.MVP.Id, "TomBrady");
            DataService.AddSeasonAward(context, nflId, 2008, Award.MVP.Id, "PeytonManning");
            DataService.AddSeasonAward(context, nflId, 2009, Award.MVP.Id, "PeytonManning");
            DataService.AddSeasonAward(context, nflId, 2010, Award.MVP.Id, "TomBrady");
            DataService.AddSeasonAward(context, nflId, 2011, Award.MVP.Id, "AaronRodgers");
            DataService.AddSeasonAward(context, nflId, 2012, Award.MVP.Id, "AdrianPeterson");
            DataService.AddSeasonAward(context, nflId, 2013, Award.MVP.Id, "PeytonManning");
            DataService.AddSeasonAward(context, nflId, 2014, Award.MVP.Id, "AaronRodgers");
            DataService.AddSeasonAward(context, nflId, 2015, Award.MVP.Id, "CamNewton");
            DataService.AddSeasonAward(context, nflId, 2016, Award.MVP.Id, "MattRyan");
            DataService.AddSeasonAward(context, nflId, 2017, Award.MVP.Id, "TomBrady");
            DataService.AddSeasonAward(context, nflId, 2018, Award.MVP.Id, "PatrickMahomes");
        }
        private static void SeedROYs(M42Context context)
        {
            int nflId = context.Leagues.Single(x => x.Abbreviation == "NFL").Id;

            DataService.AddSeasonAward(context, nflId, 1967, Award.ROYOffense.Id, "MelFarr");
            DataService.AddSeasonAward(context, nflId, 1968, Award.ROYOffense.Id, "EarlMcCullouch");
            DataService.AddSeasonAward(context, nflId, 1969, Award.ROYOffense.Id, "CalvinHill");
            DataService.AddSeasonAward(context, nflId, 1970, Award.ROYOffense.Id, "DennisShaw");
            DataService.AddSeasonAward(context, nflId, 1971, Award.ROYOffense.Id, "JohnBrockington");
            DataService.AddSeasonAward(context, nflId, 1972, Award.ROYOffense.Id, "FrancoHarris");
            DataService.AddSeasonAward(context, nflId, 1973, Award.ROYOffense.Id, "ChuckForeman");
            DataService.AddSeasonAward(context, nflId, 1974, Award.ROYOffense.Id, "DonWoods");
            DataService.AddSeasonAward(context, nflId, 1975, Award.ROYOffense.Id, "MikeThomas");
            DataService.AddSeasonAward(context, nflId, 1976, Award.ROYOffense.Id, "SammyWhite");
            DataService.AddSeasonAward(context, nflId, 1977, Award.ROYOffense.Id, "TonyDorsett");
            DataService.AddSeasonAward(context, nflId, 1978, Award.ROYOffense.Id, "EarlCampbell");
            DataService.AddSeasonAward(context, nflId, 1979, Award.ROYOffense.Id, "OttisAnderson");
            DataService.AddSeasonAward(context, nflId, 1980, Award.ROYOffense.Id, "BillySims");
            DataService.AddSeasonAward(context, nflId, 1981, Award.ROYOffense.Id, "GeorgeRogers");
            DataService.AddSeasonAward(context, nflId, 1982, Award.ROYOffense.Id, "MarcusAllen");
            DataService.AddSeasonAward(context, nflId, 1983, Award.ROYOffense.Id, "DanMarino");
            DataService.AddSeasonAward(context, nflId, 1984, Award.ROYOffense.Id, "LouisLipps");
            DataService.AddSeasonAward(context, nflId, 1985, Award.ROYOffense.Id, "EddieBrown");
            DataService.AddSeasonAward(context, nflId, 1986, Award.ROYOffense.Id, "RuebenMayes");
            DataService.AddSeasonAward(context, nflId, 1987, Award.ROYOffense.Id, "TroyStradford");
            DataService.AddSeasonAward(context, nflId, 1988, Award.ROYOffense.Id, "JohnStephens");
            DataService.AddSeasonAward(context, nflId, 1989, Award.ROYOffense.Id, "BarrySanders");
            DataService.AddSeasonAward(context, nflId, 1990, Award.ROYOffense.Id, "EmmittSmith");
            DataService.AddSeasonAward(context, nflId, 1991, Award.ROYOffense.Id, "LeonardRussell");
            DataService.AddSeasonAward(context, nflId, 1992, Award.ROYOffense.Id, "CarlPickens");
            DataService.AddSeasonAward(context, nflId, 1993, Award.ROYOffense.Id, "JeromeBettis");
            DataService.AddSeasonAward(context, nflId, 1994, Award.ROYOffense.Id, "MarshallFaulk");
            DataService.AddSeasonAward(context, nflId, 1995, Award.ROYOffense.Id, "CurtisMartin");
            DataService.AddSeasonAward(context, nflId, 1996, Award.ROYOffense.Id, "EddieGeorge");
            DataService.AddSeasonAward(context, nflId, 1997, Award.ROYOffense.Id, "WarrickDunn");
            DataService.AddSeasonAward(context, nflId, 1998, Award.ROYOffense.Id, "RandyMoss");
            DataService.AddSeasonAward(context, nflId, 1999, Award.ROYOffense.Id, "EdgerrinJames");
            DataService.AddSeasonAward(context, nflId, 2000, Award.ROYOffense.Id, "MikeAnderson");
            DataService.AddSeasonAward(context, nflId, 2001, Award.ROYOffense.Id, "AnthonyThomas");
            DataService.AddSeasonAward(context, nflId, 2002, Award.ROYOffense.Id, "ClintonPortis");
            DataService.AddSeasonAward(context, nflId, 2003, Award.ROYOffense.Id, "AnquanBoldin");
            DataService.AddSeasonAward(context, nflId, 2004, Award.ROYOffense.Id, "BenRoethlisberger");
            DataService.AddSeasonAward(context, nflId, 2005, Award.ROYOffense.Id, "CadillacWilliams");
            DataService.AddSeasonAward(context, nflId, 2006, Award.ROYOffense.Id, "VinceYoung");
            DataService.AddSeasonAward(context, nflId, 2007, Award.ROYOffense.Id, "AdrianPeterson");
            DataService.AddSeasonAward(context, nflId, 2008, Award.ROYOffense.Id, "MattRyan");
            DataService.AddSeasonAward(context, nflId, 2009, Award.ROYOffense.Id, "PercyHarvin");
            DataService.AddSeasonAward(context, nflId, 2010, Award.ROYOffense.Id, "SamBradford");
            DataService.AddSeasonAward(context, nflId, 2011, Award.ROYOffense.Id, "CamNewton");
            DataService.AddSeasonAward(context, nflId, 2012, Award.ROYOffense.Id, "RobertGriffinIII");
            DataService.AddSeasonAward(context, nflId, 2013, Award.ROYOffense.Id, "EddieLacy");
            DataService.AddSeasonAward(context, nflId, 2014, Award.ROYOffense.Id, "OdellBeckham");
            DataService.AddSeasonAward(context, nflId, 2015, Award.ROYOffense.Id, "ToddGurley");
            DataService.AddSeasonAward(context, nflId, 2016, Award.ROYOffense.Id, "DakPrescott");
            DataService.AddSeasonAward(context, nflId, 2017, Award.ROYOffense.Id, "AlvinKamara");
            DataService.AddSeasonAward(context, nflId, 2018, Award.ROYOffense.Id, "SaquonBarkley");

            DataService.AddSeasonAward(context, nflId, 1967, Award.ROYDefense.Id, "LemBarney");
            DataService.AddSeasonAward(context, nflId, 1968, Award.ROYDefense.Id, "ClaudeHumphrey");
            DataService.AddSeasonAward(context, nflId, 1969, Award.ROYDefense.Id, "JoeGreene");
            DataService.AddSeasonAward(context, nflId, 1970, Award.ROYDefense.Id, "BruceTaylor");
            DataService.AddSeasonAward(context, nflId, 1971, Award.ROYDefense.Id, "IsiahRobertson");
            DataService.AddSeasonAward(context, nflId, 1972, Award.ROYDefense.Id, "WillieBuchanon");
            DataService.AddSeasonAward(context, nflId, 1973, Award.ROYDefense.Id, "WallyChambers");
            DataService.AddSeasonAward(context, nflId, 1974, Award.ROYDefense.Id, "JackLambert");
            DataService.AddSeasonAward(context, nflId, 1975, Award.ROYDefense.Id, "RobertBrazile");
            DataService.AddSeasonAward(context, nflId, 1976, Award.ROYDefense.Id, "MikeHaynes");
            DataService.AddSeasonAward(context, nflId, 1977, Award.ROYDefense.Id, "AJDuhe");
            DataService.AddSeasonAward(context, nflId, 1978, Award.ROYDefense.Id, "AlBaker");
            DataService.AddSeasonAward(context, nflId, 1979, Award.ROYDefense.Id, "JimHaslett");
            DataService.AddSeasonAward(context, nflId, 1980, Award.ROYDefense.Id, "BuddyCurry");
            DataService.AddSeasonAward(context, nflId, 1980, Award.ROYDefense.Id, "AlRichardson");
            DataService.AddSeasonAward(context, nflId, 1981, Award.ROYDefense.Id, "LawrenceTaylor");
            DataService.AddSeasonAward(context, nflId, 1982, Award.ROYDefense.Id, "ChipBanks");
            DataService.AddSeasonAward(context, nflId, 1983, Award.ROYDefense.Id, "VernonMaxwell");
            DataService.AddSeasonAward(context, nflId, 1984, Award.ROYDefense.Id, "BillMaas");
            DataService.AddSeasonAward(context, nflId, 1985, Award.ROYDefense.Id, "DuaneBickett");
            DataService.AddSeasonAward(context, nflId, 1986, Award.ROYDefense.Id, "LeslieONeal");
            DataService.AddSeasonAward(context, nflId, 1987, Award.ROYDefense.Id, "ShaneConlan");
            DataService.AddSeasonAward(context, nflId, 1988, Award.ROYDefense.Id, "ErikMcMillan");
            DataService.AddSeasonAward(context, nflId, 1989, Award.ROYDefense.Id, "DerrickThomas");
            DataService.AddSeasonAward(context, nflId, 1990, Award.ROYDefense.Id, "MarkCarrier");
            DataService.AddSeasonAward(context, nflId, 1991, Award.ROYDefense.Id, "MikeCroel");
            DataService.AddSeasonAward(context, nflId, 1992, Award.ROYDefense.Id, "DaleCarter");
            DataService.AddSeasonAward(context, nflId, 1993, Award.ROYDefense.Id, "DanaStubblefield");
            DataService.AddSeasonAward(context, nflId, 1994, Award.ROYDefense.Id, "TimBowens");
            DataService.AddSeasonAward(context, nflId, 1995, Award.ROYDefense.Id, "HughDouglas");
            DataService.AddSeasonAward(context, nflId, 1996, Award.ROYDefense.Id, "SimeonRice");
            DataService.AddSeasonAward(context, nflId, 1997, Award.ROYDefense.Id, "PeterBoulware");
            DataService.AddSeasonAward(context, nflId, 1998, Award.ROYDefense.Id, "CharlesWoodson");
            DataService.AddSeasonAward(context, nflId, 1999, Award.ROYDefense.Id, "JevonKearse");
            DataService.AddSeasonAward(context, nflId, 2000, Award.ROYDefense.Id, "BrianUrlacher");
            DataService.AddSeasonAward(context, nflId, 2001, Award.ROYDefense.Id, "KendrellBell");
            DataService.AddSeasonAward(context, nflId, 2002, Award.ROYDefense.Id, "JuliusPeppers");
            DataService.AddSeasonAward(context, nflId, 2003, Award.ROYDefense.Id, "TerrellSuggs");
            DataService.AddSeasonAward(context, nflId, 2004, Award.ROYDefense.Id, "JonathanVilma");
            DataService.AddSeasonAward(context, nflId, 2005, Award.ROYDefense.Id, "ShawneMerriman");
            DataService.AddSeasonAward(context, nflId, 2006, Award.ROYDefense.Id, "DeMecoRyans");
            DataService.AddSeasonAward(context, nflId, 2007, Award.ROYDefense.Id, "PatrickWillis");
            DataService.AddSeasonAward(context, nflId, 2008, Award.ROYDefense.Id, "JerodMayo");
            DataService.AddSeasonAward(context, nflId, 2009, Award.ROYDefense.Id, "BrianCushing");
            DataService.AddSeasonAward(context, nflId, 2010, Award.ROYDefense.Id, "NdamukongSuh");
            DataService.AddSeasonAward(context, nflId, 2011, Award.ROYDefense.Id, "VonMiller");
            DataService.AddSeasonAward(context, nflId, 2012, Award.ROYDefense.Id, "LukeKuechly");
            DataService.AddSeasonAward(context, nflId, 2013, Award.ROYDefense.Id, "SheldonRichardson");
            DataService.AddSeasonAward(context, nflId, 2014, Award.ROYDefense.Id, "AaronDonald");
            DataService.AddSeasonAward(context, nflId, 2015, Award.ROYDefense.Id, "MarcusPeters");
            DataService.AddSeasonAward(context, nflId, 2016, Award.ROYDefense.Id, "JoeyBosa");
            DataService.AddSeasonAward(context, nflId, 2017, Award.ROYDefense.Id, "MarshonLattimore");
            DataService.AddSeasonAward(context, nflId, 2018, Award.ROYDefense.Id, "DariusLeonard");
        }
    
        private static void SeedRegularSeasons(M42Context context)
        {
            int nflId = context.Leagues.Include("Organization").Single(x => x.Organization.Identifier == "NFL").Id;

            for (int year = 2018; year < 2020; year++)
            {
                int seasonId = context.Seasons.Single(x => x.LeagueId == nflId && x.Year == year).Id;

                string seasonFileName = System.IO.Path.Combine(Constants.NFLSeasonsFolder, string.Format("{0} Schedule.csv", year));

                string[] lines = File.ReadAllLines(seasonFileName);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    //1,Thu,5-Sep,8:20PM,Green Bay Packers,@,Chicago Bears,10,3
                    string weekNumber = values[0];
                    string dayOfWeek = values[1];
                    string gameDate = values[2];
                    string gameTime = values[3];
                    string winningTeamFullName = values[4];
                    string awayIndicator = values[5];
                    string losingTeamFullName = values[6];
                    string winningScoreText = values[7];
                    string losingScoreText = values[8];

                    string[] winningTeamParts = winningTeamFullName.Split(' ');
                    string[] losingTeamParts = losingTeamFullName.Split(' ');

                    string winningTeamName = winningTeamParts[1];
                    string losingTeamName = losingTeamParts[1];

                    if (winningTeamParts.Length == 3)
                    {
                        winningTeamName = winningTeamParts[2];
                    }
                    if (losingTeamParts.Length == 3)
                    {
                        losingTeamName = losingTeamParts[2];
                    }

                    var winningTeam = context.Teams.SingleOrDefault(x => x.SeasonId == seasonId && x.Name == winningTeamName);
                    var losingTeam = context.Teams.SingleOrDefault(x => x.SeasonId == seasonId && x.Name == losingTeamName);

                    if (winningTeam == null || losingTeam == null)
                    {
                        throw new Exception("Invalid team");
                    }

                    int homeTeamId;
                    int awayTeamId; 
                    //int? winningTeamId = null;
                    //int? losingTeamId = null;
                    int? winningScore = null;
                    int? losingScore = null;
                    

                    if (winningScoreText != "") // game has been played
                    { 
                        if (awayIndicator == "@")
                        {
                            homeTeamId = losingTeam.Id;
                            awayTeamId = winningTeam.Id;
                        }
                        else
                        {
                            homeTeamId = winningTeam.Id;
                            awayTeamId = losingTeam.Id;
                        }
                        winningScore = Int32.Parse(winningScoreText);
                        losingScore = Int32.Parse(losingScoreText);
                    }
                    else
                    {
                        homeTeamId = losingTeam.Id;
                        awayTeamId = winningTeam.Id;
                    }

                    var game = new Game
                    {
                        SeasonId = seasonId,
                        GameTypeId = GameType.RegularSeason.Id ,
                        HomeTeamId = homeTeamId,
                        AwayTeamId = awayTeamId,
                        WinningTeamId = winningTeam.Id,
                        LosingTeamId = losingTeam.Id,
                        WinningScore = winningScore ,
                        LosingScore = losingScore ,
                        SortOrder = Int32.Parse(weekNumber)
                    };

                    context.Games.Add(game);
                    context.SaveChanges();
                }
            }
        }
    }

}