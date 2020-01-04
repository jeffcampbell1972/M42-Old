using System;
using System.Collections.Generic;
using System.Text;
using M42.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using M42.Sports;

namespace M42.SportsCards
{
    public class CardSearchService : ISearchService<CardSearch>
    {
        M42Context _m42;
        public CardSearchService(M42Context m42)
        {
            _m42 = m42;
        }
        public CardSearch Get()
        {
            var cardSearch = new CardSearch
            {
                Years = _m42.Releases.Select(x => x.Year).Distinct().OrderBy(x => x).ToList()
            };

            return cardSearch;
        }
        public CardSearch Get(CardSearch cardSearch)
        {
            int totalCards = _m42.Cards.Count();
            cardSearch.TotalCards = totalCards;

            if (cardSearch.HasFilter)
            {
                var cardsData = _m42.Cards
                     .Include(x => x.Set)
                     .Include(x => x.Set.Release)
                     .Include(x => x.Set.Release.Brand)
                     .Include(x => x.Set.Release.League)
                     .Include(x => x.Set.Release.League.Sport)
                     .Where(x => cardSearch.Year == null || x.Set.Release.Year == cardSearch.Year)
                     .ToList();

                var cards = cardsData.Select(x => new Card
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    CardNumber = x.CardNumber,
                    IsRookieCard = x.IsRookieCard == true,
                    IsAutographed = x.HasAutograph == true,
                    IsRelic = x.HasRelic == true,
                    Set = new Set
                    {
                        Id = x.Set.Id,
                        Identifier = x.Set.Identifier,
                        Name = x.Set.Name,
                        NumCards = x.Set.NumCards,
                        Release = new Release
                        {
                            Id = x.Set.Release.Id,
                            Identifier = x.Set.Release.Identifier,
                            Name = x.Set.Release.ToString()
                        }
                    },
                    Name = string.Format("{0} #{1}", x.Set.ToString(), x.CardNumber),
                    People = x.CardPeople.Select(x => new Person { Id = x.Person.Id, Identifier = x.Person.Identifier, Name = x.Person.ToString() }).ToList()

                })
                .ToList();

                cardSearch.Years = cards.Select(x => x.Set.Release.Year).Distinct().OrderBy(x => x).ToList();
                cardSearch.People = _m42.CardPeople
                    .Where(x => cardSearch.Year == null || x.Card.Set.Release.Year == cardSearch.Year)
                    .Select(x => x.Person)
                    .Distinct()
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ToList()
                    .Select(x => new Person { Id = x.Id, Name = x.ToString() })
                    .ToList();

                cardSearch.Cards = cards;
            }
            else
            {
                cardSearch.Years = _m42.Releases.Select(x => x.Year).Distinct().OrderBy(x => x).ToList();
                cardSearch.People = _m42.CardPeople
                    .Select(x => x.Person)
                    .Distinct()
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ToList()
                    .Select(x => new Person { Id = x.Id, Name = x.ToString() })
                    .ToList();
            }
        

            return cardSearch;
        }

    }
}
