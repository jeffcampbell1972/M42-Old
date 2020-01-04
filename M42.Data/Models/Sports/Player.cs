using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Players", Schema = "Sports")]
    public class Player
    {
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }
        public int? CollegeId { get; set; }

        public virtual Person Person { get; set; }
        public virtual College College { get; set; }

        public virtual IEnumerable<PlayerLeague> Leagues { get; set; }
    }
}