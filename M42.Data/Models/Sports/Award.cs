using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Awards", Schema = "Sports")]
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        private static List<Award> values;
        public static List<Award> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Award>() {
                        HeismanTrophy ,
                        MVP ,
                        AllPro ,
                        AllStar,
                        ROYDefense ,
                        ROYOffense
                    };
                }
                return values;
            }
        }

        static private Award heismantrophy;
        static private Award mvp;
        static private Award allpro;
        static private Award allstar;
        static private Award roydefense;
        static private Award royoffense;

        static public Award HeismanTrophy { get { return heismantrophy ?? (heismantrophy = new Award { Id = 1, Name = "Heisman Trophy", Identifier = "Heisman" }); } }
        static public Award MVP { get { return mvp ?? (mvp = new Award { Id = 2, Name = "Associated Press MVP", Identifier = "AP-MVP" }); } }
        static public Award AllPro { get { return allpro ?? (allpro = new Award { Id = 3, Name = "All-Pro", Identifier = "All-Pro" }); } }
        static public Award AllStar { get { return allstar ?? (allstar = new Award { Id = 4, Name = "All-Star", Identifier = "All-Star" }); } }
        static public Award ROYDefense { get { return roydefense ?? (roydefense = new Award { Id = 5, Name = "Defensive Rookie of the Year", Identifier = "ROY-Defense" }); } }
        static public Award ROYOffense { get { return royoffense ?? (royoffense = new Award { Id = 6, Name = "Offensive Rookie of the Year", Identifier = "ROY-Offense" }); } }
    }
}
