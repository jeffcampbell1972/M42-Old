using System;
using System.Collections.Generic;
using System.Text;
using M42.SportsCards;

namespace M42.Sports
{
    public class Franchise
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Ties { get; set; }
        public int? YearEstablished { get; set; }
        public int? YearEnded { get; set; }
        public Person Owner { get; set; }
        public Person HeadCoach { get; set; }
        public List<Person> AssistantCoaches { get; set; }
        public List<Person> Roster { get; set; }
        public List<Person> NotablePlayers { get; set; }
        public List<HallOfFamer> HallOfFamers { get; set; }

        public League League { get; set; }
        public List<Team> Teams { get; set; }

        public List<Card> Cards { get; set; }
    }
}
