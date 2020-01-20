using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.SportsCards;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace M42.Web.SportsCards
{
    public class CardSearchViewModel
    {

        public CardSearchViewModel(ISearchService<CardSearch> cardSearchService)
        {
            CardSearch = cardSearchService.Get();

            Years = CardSearch.Years
                .Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString()
                })
                .ToList();
            Years.Insert(0, new SelectListItem { Value = "", Text = "[All Years]", Selected = CardSearch.Year == null });
            Sports = CardSearch.Sports
              .Select(x => new SelectListItem
              {
                  Value = x.Id.ToString(),
                  Text = x.Name
              })
              .ToList();
            Sports.Insert(0, new SelectListItem { Value = "", Text = "[All Sports]", Selected = CardSearch.SportId == null });
            
            People = CardSearch.People
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem 
                { 
                    Value = x.Id.ToString(), 
                    Text = x.Name 
                })
                .ToList();
            People.Insert(0, new SelectListItem { Value = "", Text = "[All People]", Selected = CardSearch.PersonId == null });
        }
        public CardSearchViewModel(ISearchService<CardSearch> cardSearchService, CardSearch cardSearch)
        {
            CardSearch = cardSearchService.Get(cardSearch);

            Years = CardSearch.Years
                .Select(x => new SelectListItem 
                { 
                    Value = x.ToString() , 
                    Text = x.ToString() ,
                    Selected = cardSearch.Year == x
                })
                .ToList();
            Years.Insert(0, new SelectListItem { Value = "", Text = "[All Years]", Selected = CardSearch.Year == null });

            Sports = CardSearch.Sports
               .Select(x => new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name,
                   Selected = cardSearch.SportId == x.Id
               })
               .ToList();
            Sports.Insert(0, new SelectListItem { Value = "", Text = "[All Sports]", Selected = CardSearch.SportId == null });

            People = CardSearch.People
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name ,
                    Selected = cardSearch.PersonId == x.Id
                })
                .ToList();
            People.Insert(0, new SelectListItem { Value = "", Text = "[All People]", Selected = CardSearch.PersonId == null });

        }
        public CardSearch CardSearch { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Sports { get; set; }
        public List<SelectListItem> People { get; set; }

    }
}
