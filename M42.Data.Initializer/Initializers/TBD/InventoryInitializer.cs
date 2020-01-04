using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializers
{
    public class InventoryInitializer
    {
        public void Seed(M42Context context)
        {
            //SeedInventoryStatuses(context);
            //SeedInventoryCategories(context);
        }
        //protected void SeedInventoryStatuses(M42Context context)
        //{
        //    foreach (var inventoryStatus in InventoryStatus.Values)
        //    {
        //        context.InventoryStatuses.Add(inventoryStatus);
        //    }
        //    context.SaveChanges();
        //}
        //protected void SeedInventoryCategories(M42Context context)
        //{
        //    foreach (var inventoryCategory in InventoryCategory.Values)
        //    {
        //        context.InventoryCategories.Add(inventoryCategory);
        //    }
        //    context.SaveChanges();
        //}
    }
}