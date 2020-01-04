using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Models
{
    public class DetailsVM
    {
        public string Identifier { get; set; }
        public string ColumnCount
        {
            get
            {
                string columnCount = "1";
                if (Items.Count > 4) columnCount = "2";
                if (Items.Count > 8) columnCount = "3";

                return columnCount;
            }
        }
        public List<DetailsItemVM> Items { get; set; }
    }
}