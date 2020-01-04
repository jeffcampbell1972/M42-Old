using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("TeamPeople", Schema = "Sports")]
    public class TeamPerson
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public int PersonId { get; set; }
        public int TeamRoleId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Person Person { get; set; }
        public virtual TeamRole TeamRole { get; set; }
    }
}