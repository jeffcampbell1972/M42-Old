using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Genres", Schema = "Music")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<Genre> values;
        public static List<Genre> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Genre>() {
                        ClassicRock ,
                        HeavyMetal ,
                        Blues ,
                        Country  ,
                        Dance ,
                        Rap ,
                        Bluegrass ,
                        Classical ,
                        Flamenco ,
                        Disco
                    };
                }
                return values;
            }
        }

        static private Genre classicrock;
        static private Genre heavymetal;
        static private Genre blues;
        static private Genre country;
        static private Genre dance;
        static private Genre rap;
        static private Genre bluegrass;
        static private Genre classical;
        static private Genre flamenco;
        static private Genre disco;

        static public Genre ClassicRock { get { return classicrock ?? (classicrock = new Genre { Id = 1, Name = "Classic Rock" }); } }
        static public Genre HeavyMetal { get { return heavymetal ?? (heavymetal = new Genre { Id = 2, Name = "Heavy Metal" }); } }
        static public Genre Blues { get { return blues ?? (blues = new Genre { Id = 3, Name = "Blues" }); } }
        static public Genre Country { get { return country ?? (country = new Genre { Id = 4, Name = "Country" }); } }
        static public Genre Dance { get { return dance ?? (dance = new Genre { Id = 5, Name = "Dance" }); } }
        static public Genre Rap { get { return rap ?? (rap = new Genre { Id = 6, Name = "Rap" }); } }
        static public Genre Bluegrass { get { return bluegrass ?? (bluegrass = new Genre { Id = 7, Name = "Bluegrass" }); } }
        static public Genre Classical { get { return classical ?? (classical = new Genre { Id = 8, Name = "Classical" }); } }
        static public Genre Flamenco { get { return flamenco ?? (flamenco = new Genre { Id = 9, Name = "Flamenco" }); } }
        static public Genre Disco { get { return disco ?? (disco = new Genre { Id = 10, Name = "Disco" }); } }
    }
}
