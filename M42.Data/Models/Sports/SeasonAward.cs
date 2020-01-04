using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("SeasonAwards", Schema = "Sports")]
    public class SeasonAward
    {
        [Key]
        public int Id { get; set; }

        public int SeasonId { get; set; }
        public int PersonId { get; set; }
        public int AwardId { get; set; }

        public virtual Award Award { get; set; }
        public virtual Season Season { get; set; }
        public virtual Person Person { get; set; }
    }
}