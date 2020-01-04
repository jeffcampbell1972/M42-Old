using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("PlayerLeagueStatistics", Schema = "Sports")]
    public class PlayerLeagueStatistic
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
        public int StatisticId { get; set; }
        public int Value { get; set; }

        public virtual Player Player { get; set; }
        public virtual League League { get; set; }
        public virtual Statistic Statistic { get; set; }
    }
}