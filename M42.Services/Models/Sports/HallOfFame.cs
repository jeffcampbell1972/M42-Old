using System.Collections.Generic;
using M42.Shared;

namespace M42.Sports
{
    public class HallOfFame
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int NumMembers { get; set; }
        public int InauguralYear { get; set; }
        public Address Address { get; set; }
        public List<HallOfFamer> Members { get; set; }
        public List<HallOfFameClass> Classes { get; set; }
    }
}
