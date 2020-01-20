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
                IsAutograph = false ,
                IsRC = false ,
                IsRelic = false
            };

            return Get(cardSearch);
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
                     .Include(x => x.CardPeople)
                     .Where(x =>
                        (cardSearch.Year == null || x.Set.Release.Year == cardSearch.Year) &&
                        (cardSearch.SportId == null || x.Set.Release.League.SportId == cardSearch.SportId) &&
                        (cardSearch.PersonId == null || x.CardPeople.SingleOrDefault(xx => xx.PersonId == cardSearch.PersonId ) != null ) &&
                        (cardSearch.IsRC == false || x.IsRookieCard == true) &&
                        (cardSearch.IsRelic == false || x.HasRelic == true) &&
                        (cardSearch.IsAutograph == false || x.HasAutograph == true)
                     )
                     .ToList();



                var cardIds = cardsData.Select(x => x.Id).ToList();

                var cardPeopleData = _m42.CardPeople
                    .Include(x => x.Person)
                    .Where(x => cardIds.Contains(x.CardId))
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
                    People = cardPeopleData.Where(y => y.CardId == x.Id).Select(x => new Person { Id = x.Person.Id, Identifier = x.Person.Identifier, Name = x.Person.ToString() }).ToList()

                })
                .ToList();

                cardSearch.Cards = cards;
            }
            else
            {
                cardSearch.Cards = new List<Card>();
            }

            cardSearch.Years = _m42.Releases.Select(x => x.Year).Distinct().OrderBy(x => x).ToList();
            cardSearch.Sports = _m42.Sports.Select(x => new Sport { Id = x.Id, Identifier = x.Name, Name = x.Name }).ToList();
            cardSearch.People = _m42.CardPeople
                .Select(x => x.Person)
                .Distinct()
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList()
                .Select(x => new Person { Id = x.Id, Name = string.Format("{0}, {1}", x.LastName, x.FirstName) })
                .ToList();

            return cardSearch;
        }
        private bool HasPerson(List<M42.Data.Models.CardPerson> cardPeople, int? personId)
        {
            if (cardPeople.SingleOrDefault(x => x.PersonId == personId) == null) return false;

            return true;
        }
    }
}
