using System;
using System.Collections.Generic;
using System.Text;
using M42.Sports;

namespace M42.Inventory
{
    public class Container
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public ContainerType ContainerType { get; set; }
        public Location Location { get; set; }
        public int NumInventory { get; set; }
        public List<InventoryItem> Contents { get; set; }
    }
}
