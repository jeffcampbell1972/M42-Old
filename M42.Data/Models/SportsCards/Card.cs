using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("Cards", Schema = "SportsCards")]
    public class Card
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int SetId { get; set; }
        public int CardNumber { get; set; }
        public int CardTypeId { get; set; }

        public bool? IsRookieCard { get; set; }
        public bool? IsSinglePrint { get; set; }
        public bool? IsVariation { get; set; }
        public bool? HasAutograph { get; set; }
        public bool? HasRelic { get; set; }
        public int? NumInstances { get; set; }

        public int? LeagueId { get; set; }
        public int? TeamId { get; set; }
        public int? GameId { get; set; }

        public virtual Set Set { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual League League { get; set; }
        public virtual Team Team { get; set; }
        public virtual Game Game { get; set; }

        public virtual List<CardPerson> CardPeople { get; set; }

        public override string ToString()
        {
            return this.ToString(""); 
        }
        public string ToString(string options)
        {
            string displayName = "";

            if (options == "PersonView")
            {
                displayName = this.Set.ToString() + " #" + this.CardNumber.ToString();
            }
            else if (options == "ReleaseView")
            {
                foreach (var cardPerson in this.CardPeople)
                {
                    if (displayName != "")
                    {
                        displayName += " / ";
                    }
                    displayName += cardPerson.Person.ToString();
                }

                if (displayName == "")
                {
                    displayName = "Unknown";
                }

                displayName = "#" + this.CardNumber.ToString() + " - " + displayName;
            }

            return displayName;
        }
    }

    
}