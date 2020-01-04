using System;
using System.Collections.Generic;
using System.Text;
using M42.SportsCards;

namespace M42.Sports
{
    public class Person
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOD { get; set; }
        public string College { get; set; }
        public int NumCards { get; set; }
        public List<DraftPick> Drafts { get; set; }

        public List<Team> PlayerTeams { get; set; }
        public List<Team> CoachTeams { get; set; }
        public List<Team> OwnerTeams { get; set; }
        public List<Season> LeagueCommissionerSeasons { get; set; }
        public List<Card> Cards { get; set; }
    }
}
