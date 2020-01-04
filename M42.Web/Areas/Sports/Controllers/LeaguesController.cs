using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class LeaguesController : Controller
    {
        private IService<League> _leagueService;
        public LeaguesController(IService<League> leagueService)
        {
            _leagueService = leagueService;
        }
        public IActionResult RedirectToDetails(string identifier)
        {
            var league = _leagueService.Get(identifier);

            return RedirectToAction("Details", new { id = league.Id });
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new LeagueViewModel(_leagueService, id, viewOption);

            return View(vm);
        }
    }
}