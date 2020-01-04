using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class HallsOfFameController : Controller
    {
        private IService<HallOfFame> _hallOfFameService;
        public HallsOfFameController(IService<HallOfFame> hallOfFameService)
        {
            _hallOfFameService = hallOfFameService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new HallOfFameViewModel(_hallOfFameService, id, viewOption);
            
            return View(vm);
        }
    }
}