using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;
using M42.SportsCards;

namespace M42.Web.Inventory
{
    [Area("Inventory")]
    public class HomeController : Controller
    {
        private ISearchService<CardSearch> _searchService;
        public HomeController(ISearchService<CardSearch> searchService)
        {
            _searchService = searchService;
        }
        public IActionResult Index()
        {
            var vm = new HomeViewModel(_searchService);

            return View();
        }
    }
}