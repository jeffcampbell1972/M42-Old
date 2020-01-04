using System.Collections.Generic;
using M42.SportsCards;

namespace M42.Sports
{
    public class Sport
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int? CompetitionStartYear { get; set; }
        public Person Inventor { get; set; }
        public List<League> Leagues { get; set; }
        public List<League> InactiveLeagues { get; set; }
        public List<HallOfFame> HallsOfFame { get; set; }
        public List<Position> Positions { get; set; }
        public List<ReleaseYear> ReleaseYears { get; set; }
    }
}
