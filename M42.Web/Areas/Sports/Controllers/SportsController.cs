using M42.Sports;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class SportsController : Controller
    {
        private IService<Sport> _sportService;
        public SportsController(IService<Sport> sportService)
        {
            _sportService = sportService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new SportViewModel(_sportService, id, viewOption);

            return View(vm);
        }
    }
}