using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Models
{
    public class MenuVM
    {
        public string Identifier { get; set; }
        public string CssClass { get; set; }

        public List<MenuItemVM> MenuItems { get; set; }
    }
}