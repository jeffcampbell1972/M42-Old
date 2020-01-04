using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class PositionsController : Controller
    {
        private IService<Position> _positionService;
        public PositionsController(IService<Position> positionService)
        {
            _positionService = positionService;
        }
        public IActionResult Details(int id)
        {
            var vm = new PositionViewModel(_positionService, id);

            return View(vm);
        }
    }
}