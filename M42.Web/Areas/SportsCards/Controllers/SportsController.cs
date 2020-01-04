using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.SportsCards
{
    [Area("SportsCards")]
    public class SportsController : Controller
    {
        private IService<Sport> _sportService;
        public SportsController(IService<Sport> sportService)
        {
            _sportService = sportService;
        }
        public IActionResult Details(int id)
        {
            var vm = new SportViewModel(_sportService, id, "");

            return View(vm);
        }
    }
}