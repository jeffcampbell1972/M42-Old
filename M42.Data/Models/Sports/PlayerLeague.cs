using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("PlayerLeagues", Schema = "Sports")]
    public class PlayerLeague
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public int LeagueId { get; set; }

        public int? PositionId { get; set; }

        public Player Player { get; set; }
        public League League { get; set; }
        public Position Position { get; set; }
    }
}