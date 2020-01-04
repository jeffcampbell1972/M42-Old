using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.Sports;

namespace M42.Web.Sports
{
    [Area("Sports")]
    public class DraftsController : Controller
    {
        private IService<Draft> _draftService;
        public DraftsController(IService<Draft> draftService)
        {
            _draftService = draftService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}