using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M42.SportsCards;

namespace M42.Web.SportsCards
{
    [Area("SportsCards")]
    public class PeopleController : Controller
    {
        private IService<Person> _personService;
        public PeopleController(IService<Person> personService)
        {
            _personService = personService;
        }
        public IActionResult Details(int id, string viewOption = "")
        {
            var vm = new PersonViewModel(_personService, id, viewOption);

            return View(vm);
        }
    }
}

