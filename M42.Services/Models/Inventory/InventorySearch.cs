using System;
using System.Collections.Generic;
using System.Text;

using M42.Sports;

namespace M42.Inventory
{
    public class InventorySearch
    {
        // Filter Data
        public List<int> Years { get; set; }
        public List<Person> People { get; set; }
        public List<Sport> Sports { get; set; }
        public List<Team> Teams { get; set; }
        public List<Location> Locations { get; set; }
        public List<Container> Containers { get; set; }

        // Filters
        public int? Year { get; set; }
        public int? PersonId { get; set; }
        public int? SportId { get; set; }
        public bool IsRC { get; set; }
        public bool IsRelic { get; set; }
        public bool IsAutograph { get; set; }


        // Results
        public int TotalInventory { get; set; }
        public int TotalLocations { get; set; }
        public int TotalContainers { get; set; }
        public int NumInventory { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }

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
