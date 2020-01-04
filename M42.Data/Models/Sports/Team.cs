using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Teams", Schema = "Sports")]
    public class Team
    {
        public int Id { get; set; }

        public int FranchiseId { get; set; }
        public int SeasonId { get; set; }
        public int? ConferenceId { get; set; }
        public int? DivisionId { get; set; }
        public int? StadiumId { get; set; }
        public string Identifier { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Ties { get; set; }

        public virtual Franchise Franchise { get; set; }
        public virtual Season Season { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Division Division { get; set; }
        public virtual Stadium Stadium { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}",
                Season.Year.ToString(),
                City,
                Name);
        }
    }
}