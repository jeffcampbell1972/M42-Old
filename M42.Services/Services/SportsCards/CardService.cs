using System;
using System.Collections.Generic;
using System.Text;
using M42.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using M42.Sports;

namespace M42.SportsCards
{
    public class CardService : IService<Card>
    {
        M42Context _m42;
        public CardService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Card> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Card Get(int id)
        {
            var cardData = _m42.Cards
                .Include(x => x.Set)
                .Include(x => x.Set.Release)
                .Include(x => x.Set.Release.Brand)
                .Include(x => x.Set.Release.League)
                .Include(x => x.Set.Release.League.Sport)
                .SingleOrDefault(x => x.Id == id);

            if (cardData == null)
            {
                throw new Exception();
            }

            var cardPeopleData = _m42.CardPeople
                .Include(x => x.Card)
                .Include(x => x.Person)
                .Where(x => x.CardId == id).ToList();

            //var inventories = _m42.Inventories
            //    .Include(x => x.Card)
            //    .Include(x => x.Location)
            //    .Where(x => x.CardId == id)
            //    .ToList()
            //    .Select(x => new InventoryItem
            //    { 
            //        Id = x.Id ,
            //        SerialNumber = string.Format("{0} of {1}", x.SerialNumber, x.Card.NumInstances ) ,
            //        Location = new Location
            //        {
            //            Id = x.Location.Id ,
            //            Name = x.Location.Name 
            //        }
            //    })
            //    .ToList();

            var attributes = new List<string>();
            if (cardData.IsRookieCard == true)
            {
                attributes.Add("Rookie Card");
            }
            if (cardData.HasAutograph == true)
            {
                attributes.Add("Autographed");
            }
            if (cardData.HasRelic == true)
            {
                attributes.Add("Relic");
            }
            if (cardData.IsSinglePrint == true)
            {
                attributes.Add("Single Print");
            }

            var card = new Card
            {
                Id = cardData.Id,
                Identifier = cardData.Identifier,
                CardNumber = cardData.CardNumber,
                IsRookieCard = cardData.IsRookieCard == true,
                IsAutographed = cardData.HasAutograph == true,
                IsRelic = cardData.HasRelic == true,
                Attributes = attributes,
                Set = new Set
                {
                    Id = cardData.Set.Id,
                    Identifier = cardData.Set.Identifier,
                    Name = cardData.Set.Name,
                    NumCards = cardData.Set.NumCards,
                    Release = new Release
                    {
                        Id = cardData.Set.Release.Id,
                        Identifier = cardData.Set.Release.Identifier,
                        Name = cardData.Set.Release.ToString()
                    }
                },
                Name = string.Format("{0} {1} {2} #{3}", cardData.Set.Release.Year, cardData.Set.Release.Brand.Name, cardData.Set.Name == "Base" ? "" : cardData.Set.Name, cardData.CardNumber) ,
                People = cardPeopleData.Select(x => new Person { Id = x.Person.Id, Identifier = x.Person.Identifier, Name = x.Person.ToString() }).ToList() 
                //Inventories = inventories
            };

            return card;
        }
        public Card Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Card card)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Card card)
        {
            throw new MethodUnsupportedException();
        }
    }
}
