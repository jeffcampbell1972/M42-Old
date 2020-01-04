using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Conferences", Schema = "Sports")]
    public class Conference
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int SortOrder { get; set; }

        public League League { get; set; }

    }
}