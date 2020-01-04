using System.Collections.Generic;

namespace M42.Sports
{
    public class Team
    {
        public int Id { get; set; }
        public string Identifier { get; set; }

        public Franchise Franchise { get; set; }
        public Season Season { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Ties { get; set; }
        public Person Owner { get; set; }
        public Person HeadCoach { get; set; }
        public List<Person> AssistantCoaches { get; set; }
        public List<Person> Roster { get; set; }
        public List<DraftPick> DraftPicks { get; set; }
        public List<HallOfFamer> HallOfFamers { get; set; }
        public List<TeamGame> RegularSeason { get; set; }
        public List<Game> PlayoffGames { get; set; }
        public List<Series> PlayoffSeries { get; set; }

        public Team NextTeam { get; set; }
        public Team PrevTeam { get; set; }
    }
}
