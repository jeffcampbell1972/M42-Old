using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Inventory;

namespace M42.Web.Inventory
{
    public class InventoryItemViewModel : BaseVM
    {

        public InventoryItemViewModel(IService<InventoryItem> inventoryService, int id)
        {
            InventoryItem = inventoryService.Get(id);
            DisplayName = InventoryItem.Name;
        }
        public InventoryItem InventoryItem { get; set; }
    }
}
