using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Sports
{
    public class HallOfFamer
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public Person Person { get; set; }
        public List<Position> Positions { get; set; }
        public HallOfFame HallOfFame { get; set; }
        public int YearInducted { get; set; }
    }
}
