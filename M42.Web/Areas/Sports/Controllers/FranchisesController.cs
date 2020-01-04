using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class FranchisesController : Controller
    {
        private IService<Franchise> _franchiseService;
        public FranchisesController(IService<Franchise> franchiseService)
        {
            _franchiseService = franchiseService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new FranchiseViewModel(_franchiseService, id, viewOption);

            return View(vm);
        }
    }
}