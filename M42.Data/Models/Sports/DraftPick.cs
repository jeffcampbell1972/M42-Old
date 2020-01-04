using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("DraftPicks", Schema = "Sports")]
    public class DraftPick
    {
        public int Id { get; set; }

        public int DraftId { get; set; }
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        public int? PositionId { get; set; }
        public int? CollegeId { get; set; }
        public int Round { get; set; }
        public int Pick { get; set; }

        public virtual Draft Draft { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
        public virtual Position Position { get; set; }
        public virtual College College { get; set; }
    }
}