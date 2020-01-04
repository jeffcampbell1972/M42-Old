using System.Collections.Generic;

namespace M42.Sports
{
    public class League
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int? YearEstablished { get; set; }
        public int? YearEnded { get; set; }
        public int NumFranchises { get; set; }
        public int NumGames { get; set; }
        public Sport Sport { get; set; }
        public Person Commissioner { get; set; }

        public HallOfFame HallOfFame { get; set; }
        public Draft Draft { get; set; }
        public List<Game> RegularSeason { get; set; }
        public List<Game> PlayoffGames { get; set; }
        public List<Season> Seasons { get; set; }
        public List<Draft> Drafts { get; set; }
        public List<Franchise> Franchises { get; set; }
        public List<Team> Champions { get; set; }
        public List<Championship> Championships { get; set; }
        public List<Person> MVPs { get; set; }
        public List<Conference> Conferences { get; set; }
        public List<Division> Divisions { get; set; }
    }
}
