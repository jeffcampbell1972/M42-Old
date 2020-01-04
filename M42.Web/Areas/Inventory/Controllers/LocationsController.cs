using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;
using M42.Inventory;

namespace M42.Web.Inventory
{
    [Area("Inventory")]
    public class LocationsController : Controller
    {
        private IService<Location> _locationService;
        public LocationsController(IService<Location> locationService)
        {
            _locationService = locationService;
        }
        public IActionResult Index()
        {
            var vm = new LocationIndexViewModel(_locationService);

            return View(vm);
        }
    }
}