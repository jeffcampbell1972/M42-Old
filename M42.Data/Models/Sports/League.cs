using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Leagues", Schema = "Sports")]
    public class League
    {
        [Key]
        [ForeignKey("Organization")]
        public int Id { get; set; }
        public int SportId { get; set; }
        public int HOFId { get; set; }
        public string Abbreviation { get; set; }
        public Organization Organization { get; set; }
        public Sport Sport { get; set; }
        public HOF HOF { get; set; }

        public IEnumerable<PlayerLeague> Players { get; set; }
    }
}