using System;
using System.Collections.Generic;
using System.Text;
using M42.SportsCards;

namespace M42.Inventory
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public Location Location { get; set; }
        public Card Card { get; set; }
    }
}
