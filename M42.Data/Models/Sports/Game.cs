using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M42.Data.Models
{
    [Table("Games", Schema = "Sports")]
    public class Game
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int GameTypeId { get; set; }
        public int? GameNumber { get; set; } 
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public int? WinningTeamId { get; set; }
        public int? WinningScore { get; set; }
        public int? LosingTeamId { get; set; }
        public int? LosingScore { get; set; }
        public int? OvertimeCount { get; set; }
        public string Stadium { get; set; }   // would like this to be a foreign key to Stadia table, but not yet
        public int? Attendence { get; set; }
        public string Notes { get; set; }

        public virtual Season Season { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual Team WinningTeam { get; set; }
        public virtual Team LosingTeam { get; set; }
    }
}