using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.SportsCards;
using Microsoft.AspNetCore.Mvc;

namespace M42.Web.SportsCards
{
    [Area("SportsCards")]
    public class CardsController : Controller
    {
        private IService<Card> _cardService;
        public CardsController(IService<Card> cardService)
        {
            _cardService = cardService;
        }
        public IActionResult Details(int id)
        {
            var vm = new CardViewModel(_cardService, id, "");

            return View(vm);
        }
    }
}