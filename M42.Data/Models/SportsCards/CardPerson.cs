using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("CardPeople", Schema = "SportsCards")]
    public class CardPerson
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int PersonId { get; set; }
        public int? TeamId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}