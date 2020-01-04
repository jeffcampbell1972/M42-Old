using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class HomeController : Controller
    {
        private IService<Sport> _sportService;
        public HomeController(IService<Sport> sportService)
        {
            _sportService = sportService;
        }
        public IActionResult Index()
        {
            var vm = new HomeViewModel(_sportService);

            return View(vm);
        }
    }
}