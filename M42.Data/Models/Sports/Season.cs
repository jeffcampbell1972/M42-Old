using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Seasons", Schema = "Sports")]
    public class Season
    {
        [Key]
        public int Id { get; set; }
        //[Index(IsUnique = true)]
        [StringLength(450)]
        public string Identifier { get; set; }

        public int LeagueId { get; set; }
        public int Year { get; set; }
        public string LeagueNameOverride { get; set; }
        public string LeagueAbbreviationOverride { get; set; }

        public int NumTeams { get; set; }
        public int NumGames { get; set; }
        public int? CommissionerId { get; set; }
        public int? PresidentId { get; set; }

        public virtual League League { get; set; }
        public virtual Person Commissioner { get; set; }
        public virtual Person President { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                Year.ToString() ,
                LeagueAbbreviationOverride ?? League.Abbreviation 
                );
        }
    }
}