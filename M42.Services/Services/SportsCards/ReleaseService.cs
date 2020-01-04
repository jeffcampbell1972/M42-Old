using System;
using System.Collections.Generic;
using System.Text;
using M42.Data;
using M42.Sports;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace M42.SportsCards
{
    public class ReleaseService : IService<Release>
    {
        M42Context _m42;
        public ReleaseService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Release> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Release Get(int id)
        {
            var releaseData = _m42.Releases
                .Include(x => x.League)
                .Include(x => x.League.Organization)
                .Include(x => x.League.Sport)
                .Include(x => x.Brand)
                .Include(x => x.Manufacturer)
                .Include(x => x.Manufacturer.Organization)
                .SingleOrDefault(x => x.Id == id);

            if (releaseData == null)
            {
                throw new Exception();
            }

            var setsData = _m42.Sets.Where(x => x.ReleaseId == id).ToList();

            var cardsData = _m42.Cards
                .Where(x => x.Set.ReleaseId == id).ToList();

            var cardPeopleData = _m42.CardPeople
                .Include(x => x.Card)
                .Include(x => x.Card.Set)
                .Include(x => x.Person)
                .Where(x => x.Card.Set.ReleaseId == id)
                .ToList();

            var sets = setsData.OrderByDescending(x => x.IsBase).Select(x => new Set
            {
                Id = x.Id,
                Identifier = x.Identifier ,
                Name = x.Name ,
                NumCards = x.NumCards , 
                IsBaseSet = x.IsBase ,
                Cards = GetCards(cardsData, cardPeopleData, x.Id)
            })
            .ToList();

            var release = new Release
            {
                Id = releaseData.Id,
                Identifier = releaseData.Identifier,
                Name = releaseData.ToString() ,
                Year = releaseData.Year ,
                Sport = new Sport { Id = releaseData.League.Sport.Id, Identifier = releaseData.League.Sport.Name, Name = releaseData.League.Sport.Name },
                League = new League { Id = releaseData.League.Id, Identifier = releaseData.League.Organization.Identifier, Name = releaseData.League.Organization.Name },
                Brand = new Brand { Id = releaseData.Brand.Id , Identifier = releaseData.Brand.Identifier, Name = releaseData.Brand.Name } ,
                Manufacturer = new Manufacturer { Id = releaseData.Manufacturer.Id, Identifier = releaseData.Manufacturer.Organization.Identifier, Name = releaseData.Manufacturer.Organization.Name },
                Sets = sets ,
                ReleaseYear = new ReleaseYear { Identifier = string.Format("{0}-{1}", releaseData.League.Sport.Name, releaseData.Year), Year = releaseData.Year }
            };

            return release;
        }
        public Release Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Release release)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Release release)
        {
            throw new MethodUnsupportedException();
        }



        private List<Card> GetCards(List<M42.Data.Models.Card> cardsData, List<M42.Data.Models.CardPerson> cardPeopleData, int setId)
        {
            var cards = cardsData
                .Where(x => x.SetId == setId)
                .OrderBy(x => x.CardNumber)
                .ToList()
                .Select(x => new Card
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    CardNumber = x.CardNumber,
                    Name = GetCardName(cardPeopleData, x.Id)
                })
                .ToList();

            return cards;
        }
        private string GetCardName (List<M42.Data.Models.CardPerson> cardPeopleData, int cardId)
        {
            var people = cardPeopleData.Where(x => x.CardId == cardId).Select(x => x.Person).ToList();

            string cardName = "";
            foreach(var person in people)
            {
                if (cardName != "")
                {
                    cardName += "/";
                }

                cardName += person.ToString();
            }

            return cardName;
        }
    }
}
