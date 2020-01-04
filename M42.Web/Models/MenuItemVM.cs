using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Models
{
    public class MenuItemVM
    {
        public string Identifier { get; set; }
        public string CssClass { get; set; }
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int Id { get; set; }
        public string ViewOption { get; set; }
        public string Area { get; set; }
        public bool IsSelected { get; set; }

        public string PartialView { get; set; }
    }
}