using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Locations", Schema = "SportsCards")]
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        private static List<Location> values;
        public static List<Location> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Location>() {
                        SedonaHouse ,
                        SedonaBOA ,
                        BurkeStorage ,
                        RichmondApartment
                    };
                }
                return values;
            }
        }

        static private Location sedonahouse;
        static private Location sedonaboa;
        static private Location burkestorage;
        static private Location richmondapartment;

        static public Location SedonaHouse { get { return sedonahouse ?? (sedonahouse = new Location { Id = 1, Name = "Sedona House", Identifier = "SedonaHouse" }); } }
        static public Location SedonaBOA { get { return sedonaboa ?? (sedonaboa = new Location { Id = 2, Name = "Sedona Bank of America", Identifier = "SedonaBOA" }); } }
        static public Location BurkeStorage { get { return burkestorage ?? (burkestorage = new Location { Id = 3, Name = "Burke Storage Unit", Identifier = "BurkeStorage" }); } }
        static public Location RichmondApartment { get { return richmondapartment ?? (richmondapartment = new Location { Id = 4, Name = "Richmond Apartment", Identifier = "RichmondApartment" }); } }
    }
}