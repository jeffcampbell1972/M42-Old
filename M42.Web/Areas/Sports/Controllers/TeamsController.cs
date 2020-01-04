using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class TeamsController : Controller
    {
        private IService<Team> _teamService;
        public TeamsController(IService<Team> teamService)
        {
            _teamService = teamService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new TeamViewModel(_teamService, id, viewOption);

            return View(vm);
        }
    }
}