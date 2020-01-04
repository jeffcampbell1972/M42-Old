using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("TeamPlayerPositions", Schema = "Sports")]
    public class TeamPlayerPosition
    {
        public int Id { get; set; }

        public int TeamPersonId { get; set; }
        public int PositionId { get; set; }

        public virtual TeamPerson TeamPerson { get; set; }
        public virtual Position Position { get; set; }
    }
}