using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.SportsCards;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.SportsCards
{
    [Area("SportsCards")]
    public class ReleasesController : Controller
    {
        private IService<Release> _releaseService;
        public ReleasesController(IService<Release> releaseService)
        {
            _releaseService = releaseService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new ReleaseViewModel(_releaseService, id, viewOption);

            return View(vm);
        }
    }
}