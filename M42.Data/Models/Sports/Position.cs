using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Positions", Schema = "Sports")]
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Abbreviation { get; set; }
        public string Identifier { get; set; }
        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
