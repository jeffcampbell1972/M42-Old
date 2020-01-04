using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Divisions", Schema = "Sports")]
    public class Division
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public int SortOrder { get; set; }

        public virtual Conference Conference { get; set; }
    }
}