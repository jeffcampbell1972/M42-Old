
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using M42.Models;

using M42.Data;
using M42.Data.Initializer;

namespace M42.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDatabaseService _databaseService;

        public HomeController(ILogger<HomeController> logger, IDatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information, "Home page.");

            var homeViewModel = new HomeViewModel(_databaseService);

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            _logger.Log(LogLevel.Information, "Begin Seeding Database.");
            _databaseService.SeedDatabase();
            _logger.Log(LogLevel.Information, "Database Seeded.");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
