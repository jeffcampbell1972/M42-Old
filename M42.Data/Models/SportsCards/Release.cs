using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Releases", Schema = "SportsCards")]
    public class Release
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int ManufacturerId { get; set; }
        public int BrandId { get; set; }
        public int LeagueId { get; set; }
        public int Year { get; set; }
        public int BaseNumCards { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual League League { get; set; }

        public override string ToString()
        {
            return this.Year.ToString() + " " + this.Brand.Name + " " + this.League.Sport.Name;
        }
    }
}