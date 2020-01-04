using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializer
{
    public static class SportsInitializer
    {
        public static void Seed(M42Context m42)
        {
            SeedFootballPositions(m42);
            SeedFootballStatistics(m42);
            SeedHOFs(m42);
            SeedStadia(m42);
        }
 
        private static void SeedHOFs(M42Context context)
        {
            context.HOFs.Add(new HOF { SportId = Sport.Baseball.Id, IsProfessional = true, Organization = new Organization { Name = "National Baseball Hall of Fame and Museum", Identifier = "Cooperstown", YearEstablished = 1939, ActiveFlag = true } });
            context.HOFs.Add(new HOF { SportId = Sport.Football.Id, IsProfessional = true, Organization = new Organization { Name = "Pro Football Hall of Fame", Identifier = "Canton", YearEstablished = 1963, ActiveFlag = true } });
            context.HOFs.Add(new HOF { SportId = Sport.Basketball.Id, IsProfessional = true, Organization = new Organization { Name = "Naismith Memorial Basketball Hall of Fame", Identifier = "Basketball-HOF", YearEstablished = 1959, ActiveFlag = true } });
            context.HOFs.Add(new HOF { SportId = Sport.Hockey.Id, IsProfessional = true, Organization = new Organization { Name = "Hockey Hall of Fame", Identifier = "Hockey-HOF", YearEstablished = 1959, ActiveFlag = true } });
            
            context.HOFs.Add(new HOF { SportId = Sport.Basketball.Id, IsProfessional = false, Organization = new Organization { Name = "National Collegiate Basketball Hall of Fame", Identifier = "NCAAB-HOF", YearEstablished = 2006, ActiveFlag = true } });
            context.HOFs.Add(new HOF { SportId = Sport.Football.Id, IsProfessional = false, Organization = new Organization { Name = "College Football Hall of Fame", Identifier = "NCAAF-HOF", YearEstablished = 1951, ActiveFlag = true } });

            context.SaveChanges();
        }
        private static void SeedStadia(M42Context context)
        {
            int usId = context.Countries.Single(x => x.ISOCode == "USA").Id;

            DataService.AddStadium(context, "RFK", "Robert F Kennedy", "RFK", "Washington", usId, State.DC.Id);
        }
        private static void SeedFootballPositions(M42Context context)
        {
            DataService.AddPosition(context, "Football-QB", "Quarterback", "QB", Sport.Football.Id, 1);
            DataService.AddPosition(context, "Football-RB", "Running Back", "RB", Sport.Football.Id, 2);
            DataService.AddPosition(context, "Football-WR", "Wide Receiver", "WR", Sport.Football.Id, 3);
            DataService.AddPosition(context, "Football-TE", "Tight End", "TE", Sport.Football.Id, 4);
            DataService.AddPosition(context, "Football-T", "Tackle", "T", Sport.Football.Id, 10);
            DataService.AddPosition(context, "Football-G", "Guard", "G", Sport.Football.Id, 11);
            DataService.AddPosition(context, "Football-C", "Center", "C", Sport.Football.Id, 12);
            DataService.AddPosition(context, "Football-DE", "Defensive End", "DE", Sport.Football.Id, 20);
            DataService.AddPosition(context, "Football-DT", "Defensive Tackle", "DT", Sport.Football.Id, 21);
            DataService.AddPosition(context, "Football-LB", "Linebacker", "LB", Sport.Football.Id, 30);
            DataService.AddPosition(context, "Football-CB", "Cornerback", "CB", Sport.Football.Id, 40);
            DataService.AddPosition(context, "Football-S", "Safety", "S", Sport.Football.Id, 41);
            DataService.AddPosition(context, "Football-K", "Kicker", "K", Sport.Football.Id, 50);
            DataService.AddPosition(context, "Football-P", "Punter", "P", Sport.Football.Id, 51);
            DataService.AddPosition(context, "Football-KR", "Kick Returner", "KR", Sport.Football.Id, 52);
            DataService.AddPosition(context, "Football-PR", "Punt Returner", "PR", Sport.Football.Id, 53);

            context.SaveChanges();
        }
        private static void SeedFootballStatistics(M42Context context)
        {
            DataService.AddStatistic(context, "Pass-Att", "Passing Attempts", "Atts", "", Sport.Football.Id, 1, 1);
            DataService.AddStatistic(context, "Pass-Cmp", "Completions", "Comps", "", Sport.Football.Id, 1, 2);
            DataService.AddStatistic(context, "Pass-Tds", "Passing TDs", "TDs", "", Sport.Football.Id, 1, 3);
            DataService.AddStatistic(context, "Pass-Int", "Passing Interceptions", "Ints", "", Sport.Football.Id, 1, 4);
            DataService.AddStatistic(context, "Pass-Rat", "Passer Rating", "Ints", "", Sport.Football.Id, 1, 5);
            DataService.AddStatistic(context, "Rushes",   "Rushing Attempts", "Rushes", "", Sport.Football.Id, 2, 1);
            DataService.AddStatistic(context, "Rush-Yds", "Rushing Yards", "Yds", "", Sport.Football.Id, 2, 2);
            DataService.AddStatistic(context, "Rush-Tds", "Rushing TDs", "TDs", "", Sport.Football.Id, 2, 3);
            DataService.AddStatistic(context, "Fumbles",  "Fumbles", "Fumbles", "", Sport.Football.Id, 2, 4);
            DataService.AddStatistic(context, "Recs",     "Receptions", "Recs", "", Sport.Football.Id, 3, 1);
            DataService.AddStatistic(context, "Rec-Tds",  "Receiving TDs", "TDs", "", Sport.Football.Id, 3, 2);
            DataService.AddStatistic(context, "Rec-Yds",  "Receiving Yards", "Yds", "", Sport.Football.Id, 3, 3);
            DataService.AddStatistic(context, "FG-Atts",  "Field Goals", "FGs", "", Sport.Football.Id, 4, 1);
            DataService.AddStatistic(context, "FGs",      "Field Goals", "FGs", "", Sport.Football.Id, 4, 2);
            DataService.AddStatistic(context, "KRs",      "Kick Returns", "KRs", "", Sport.Football.Id, 5, 1);
            DataService.AddStatistic(context, "KR-Yds",   "Kick Return Yards", "Yds", "", Sport.Football.Id, 5, 2);
            DataService.AddStatistic(context, "KR-Tds",   "Kick Return TDs", "TDs", "", Sport.Football.Id, 5, 3);
            DataService.AddStatistic(context, "PRs",      "Punt Returns", "PRs", "", Sport.Football.Id, 6, 1);
            DataService.AddStatistic(context, "PR-Yds",   "Punt Return Yards", "Yds", "", Sport.Football.Id, 6, 2);
            DataService.AddStatistic(context, "PR-Tds",   "Punt Return TDs", "TDs", "", Sport.Football.Id, 6, 3);
            DataService.AddStatistic(context, "Int-Int",  "Interceptions", "Ints", "", Sport.Football.Id, 7, 1);
            DataService.AddStatistic(context, "Int-Yds",  "Interception Return Yards", "Yds", "", Sport.Football.Id, 7, 2);
            DataService.AddStatistic(context, "Int-Tds",  "Interception TDs", "TDs", "", Sport.Football.Id, 7, 3);

            context.SaveChanges();
        }

    }

}