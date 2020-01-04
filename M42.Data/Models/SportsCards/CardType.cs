using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("CardTypes", Schema = "SportsCards")]
    public class CardType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        private static List<CardType> values;
        public static List<CardType> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<CardType>() {
                        Regular ,
                        Checklist ,
                        LeagueLeaders ,
                        Team ,
                        RecordBreaker ,
                        SemiFinal ,
                        Championship ,
                        SuperBowl ,
                        AllPro
                    };
                }
                return values;
            }
        }

        static private CardType regular;
        static private CardType checklist;
        static private CardType leagueLeaders;
        static private CardType team;
        static private CardType recordBreaker;
        static private CardType semiFinal;
        static private CardType championship;
        static private CardType superBowl;
        static private CardType allPro;

        static public CardType Regular { get { return regular ?? (regular = new CardType { Id = 1, Name = "Regular", Identifier = "Regular" }); } }
        static public CardType Checklist { get { return checklist ?? (checklist = new CardType { Id = 2, Name = "Checklist", Identifier = "Checklist" }); } }
        static public CardType LeagueLeaders { get { return leagueLeaders ?? (leagueLeaders = new CardType { Id = 3, Name = "League Leaders", Identifier = "LeagueLeaders" }); } }
        static public CardType Team { get { return team ?? (team = new CardType { Id = 4, Name = "Team", Identifier = "Team" }); } }
        static public CardType RecordBreaker { get { return recordBreaker ?? (recordBreaker = new CardType { Id = 5, Name = "Record Breaker", Identifier = "RecordBreaker" }); } }
        static public CardType SemiFinal { get { return semiFinal ?? (semiFinal = new CardType { Id = 6, Name = "Playoffs - Semi-Final", Identifier = "SemiFinal" }); } }
        static public CardType Championship { get { return championship ?? (championship = new CardType { Id = 7, Name = "Playoffs - Conference Championship", Identifier = "Championship" }); } }
        static public CardType SuperBowl { get { return superBowl ?? (superBowl = new CardType { Id = 8, Name = "Playoffs - Super Bowl", Identifier = "SuperBowl" }); } }
        static public CardType AllPro { get { return allPro ?? (allPro = new CardType { Id = 9, Name = "All-Pro", Identifier = "AllPro" }); } }
    }
}