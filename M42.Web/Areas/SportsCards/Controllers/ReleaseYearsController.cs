using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;
using M42.SportsCards;

namespace M42.Web.SportsCards
{
    [Area("SportsCards")]
    public class ReleaseYearsController : Controller
    {
        private IReleaseYearService _releaseYearService;
        public ReleaseYearsController(IReleaseYearService releaseYearService)
        {
            _releaseYearService = releaseYearService;
        }

        public IActionResult Details(string identifier)
        {
            var vm = new ReleaseYearViewModel(_releaseYearService, identifier, "");

            return View(vm);
        }
    }
}