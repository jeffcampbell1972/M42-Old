using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class Season
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public League League { get; set; }
        public Person Commissioner { get; set; }
        public int? NumTeams { get; set; }
        public int? NumGames { get; set; }
        public List<Team> Teams { get; set; }
        public Team Champion { get; set; }
        public Championship Championship { get; set; }
        public List<Game> Playoffs { get; set; }
        public List<Game> RegularSeason { get; set; }
        public Person MVP { get; set; }
        public Person OffensiveROY { get; set; }
        public Person DefensiveROY { get; set; }
        public List<HallOfFamer> HallOfFamers { get; set; }

        public Draft Draft { get; set; }
        public List<Conference> Conferences { get; set; }
        public List<Division> Divisions { get; set; }

        public Season NextSeason { get; set; }
        public Season PrevSeason { get; set; }
    }
}
