using System.Collections.Generic;

namespace M42.Sports
{
    public class Position
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public Sport Sport { get; set; }
        public List<Person> People { get; set; }
    }
}
