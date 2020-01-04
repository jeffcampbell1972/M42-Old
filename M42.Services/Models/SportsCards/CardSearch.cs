using System;
using System.Collections.Generic;
using System.Text;

using M42.Sports;

namespace M42.SportsCards
{
    public class CardSearch
    {
        public int TotalCards { get; set; }
        public List<int> Years { get; set; }
        public List<Person> People { get; set; }
        public List<Team> Teams { get; set; }
        public int? Year { get; set; }
        public int? PersonId { get; set; }

        public int NumCards { get; set; }
        public List<Card> Cards { get; set; }

        public bool HasFilter
        {
            get 
            { 
                if (Year != null || PersonId != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
