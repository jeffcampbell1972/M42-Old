using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;
using M42.SportsCards;
using M42.Inventory;

namespace M42.Web.Inventory
{
    [Area("Inventory")]
    public class InventoryItemsController : Controller
    {
        private IService<InventoryItem> _inventoryService;
        public InventoryItemsController(IService<InventoryItem> inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public IActionResult Details(int id)
        {
            var vm = new InventoryItemViewModel( _inventoryService, id);

            return View(vm);
        }
    }
}