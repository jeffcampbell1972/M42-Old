using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Sports", Schema = "Sports")]
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private static List<Sport> values;
        public static List<Sport> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Sport>() {
                        Football ,
                        Baseball ,
                        Basketball ,
                        Hockey ,
                        Golf ,
                        Tennis
                    };
                }
                return values;
            }
        }

        static private Sport football;
        static private Sport baseball;
        static private Sport basketball;
        static private Sport hockey;
        static private Sport golf;
        static private Sport tennis;

        static public Sport Football { get { return football ?? (football = new Sport { Id = 1, Name = "Football" }); } }
        static public Sport Baseball { get { return baseball ?? (baseball = new Sport { Id = 2, Name = "Baseball" }); } }
        static public Sport Basketball { get { return basketball ?? (basketball = new Sport { Id = 3, Name = "Basketball" }); } }
        static public Sport Hockey { get { return hockey ?? (hockey = new Sport { Id = 4, Name = "Hockey" }); } }
        static public Sport Golf { get { return golf ?? (golf = new Sport { Id = 5, Name = "Golf" }); } }
        static public Sport Tennis { get { return tennis ?? (tennis = new Sport { Id = 6, Name = "Tennis" }); } }
    }
}
