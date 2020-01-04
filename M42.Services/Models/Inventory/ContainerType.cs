using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Inventory
{
    public class ContainerType
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        public List<Container> Containers { get; set; }
    }
}
