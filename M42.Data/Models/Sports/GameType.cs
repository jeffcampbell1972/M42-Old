using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("GameTypes", Schema = "Sports")]
    public class GameType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int SortOrder { get; set; }

        private static List<GameType> values;
        public static List<GameType> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<GameType>() {
                        SuperBowl ,
                        LeagueChampionship,
                        ConferenceChampionship,
                        Divisional ,
                        Wildcard ,
                        Playoff ,
                        RegularSeason 
                    };
                }
                return values;
            }
        }

        static private GameType superbowl;
        static private GameType leaguechampionship;
        static private GameType conferencechampionship;
        static private GameType divisional;
        static private GameType wildcard;
        static private GameType playoff;
        static private GameType regularseason;

        static public GameType SuperBowl { get { return superbowl ?? (superbowl = new GameType { Id = 1, Name = "Super Bowl", Identifier = "SuperBowl", SortOrder = 300 }); } }
        static public GameType LeagueChampionship { get { return leaguechampionship ?? (leaguechampionship = new GameType { Id = 2, Name = "Championship", Identifier = "LeagueChampionship", SortOrder = 200 }); } }
        static public GameType ConferenceChampionship { get { return conferencechampionship ?? (conferencechampionship = new GameType { Id = 3, Name = "Conference Championship", Identifier = "ConferenceChampionship", SortOrder = 100 }); } }
        static public GameType Divisional { get { return divisional ?? (divisional = new GameType { Id = 4, Name = "Divisional Playoff", Identifier = "Divisional", SortOrder = 50 }); } }
        static public GameType Wildcard { get { return wildcard ?? (wildcard = new GameType { Id = 5, Name = "Wildcard Game", Identifier = "Wildcard", SortOrder = 25 }); } }
        static public GameType Playoff { get { return playoff ?? (playoff = new GameType { Id = 6, Name = "Playoff Game", Identifier = "Playoff", SortOrder = 25 }); } }
        static public GameType RegularSeason { get { return regularseason ?? (regularseason = new GameType { Id = 7, Name = "Regular Season", Identifier = "Regular", SortOrder = 10 }); } }
    }
}