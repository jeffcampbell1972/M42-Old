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
        private ISearchService<CardSearch> _searchService;
        private IService<Card> _cardService;
        public CardsController(IService<Card> cardService, ISearchService<CardSearch> searchService)
        {
            _cardService = cardService;
            _searchService = searchService;
        }
        public IActionResult Details(int id)
        {
            var vm = new CardViewModel(_cardService, id, "");

            return View(vm);
        }
        public IActionResult Index()
        {
            var vm = new CardSearchViewModel(_searchService);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(CardSearch cardSearch)
        {
            var vm = new CardSearchViewModel(_searchService, cardSearch);

            return View(vm);
        }
    }
}