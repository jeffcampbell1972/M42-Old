using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.SportsCards;

namespace M42.Web.Inventory
{
    public class HomeViewModel : BaseVM
    {

        public HomeViewModel(ISearchService<CardSearch> cardSearchService)
        {
            CardSearch = cardSearchService.Get();


        }
        public CardSearch CardSearch { get; set; }
    }
}
