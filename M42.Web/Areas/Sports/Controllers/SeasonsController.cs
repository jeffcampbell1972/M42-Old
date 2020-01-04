using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class SeasonsController : Controller
    {
        private IService<Season> _seasonService;
        public SeasonsController(IService<Season> seasonService)
        {
            _seasonService = seasonService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new SeasonViewModel(_seasonService, id, viewOption);

            return View(vm);
        }
    }
}