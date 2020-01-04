using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.Inventory
{
    [Area("Inventory")]
    public class ContainersController : Controller
    {
        private IService<Container> _containerService;
        public ContainersController(IService<Container> containerService)
        {
            _containerService = containerService;
        }
        public IActionResult Index(string viewOption = "")
        {
            var vm = new ContainerIndexViewModel(_containerService, viewOption);

            return View(vm);
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new ContainerViewModel(_containerService, id, viewOption);

            return View(vm);
        }
    }
}