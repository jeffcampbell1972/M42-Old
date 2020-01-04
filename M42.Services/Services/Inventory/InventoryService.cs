using M42.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M42.SportsCards;

namespace M42.Inventory
{
    public class InventoryService : IService<InventoryItem>
    {

        M42Context _m42;
        public InventoryService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<InventoryItem> Get()
        {
            throw new MethodUnsupportedException();
        }
        public InventoryItem Get(int id)
        {
            var inventoryData = _m42.Inventories
                .Include(x => x.Card)
                .Include(x => x.Card.Set)
                .Include(x => x.Card.Set.Release)
                .Include(x => x.Card.Set.Release.Brand)
                .Include(x => x.Card.Set.Release.League)
                .SingleOrDefault(x => x.Id == id);

            if (inventoryData == null)
            {
                throw new Exception("Invalid Id to Inventories provided.");
            }

            var cardPeopleData = _m42.CardPeople
               .Include(x => x.Card)
               .Include(x => x.Person)
               .Where(x => x.CardId == inventoryData.CardId).ToList();

            var inventoryItem = new InventoryItem
            {
                Id = inventoryData.Id,
                //SerialNumber = inventoryData.SerialNumber ,
                Name = string.Format("{0} {1} {2} #{3}", inventoryData.Card.Set.Release.Year, inventoryData.Card.Set.Release.Brand.Name, inventoryData.Card.Set.Name == "Base" ? "" : inventoryData.Card.Set.Name, inventoryData.Card.CardNumber),
                Card = new Card
                {
                    Id = inventoryData.Card.Id ,
                    Identifier = inventoryData.Card.Identifier,
                    CardNumber = inventoryData.Card.CardNumber,
                    IsRookieCard = inventoryData.Card.IsRookieCard == true,
                    IsAutographed = inventoryData.Card.HasAutograph == true,
                    IsRelic = inventoryData.Card.HasRelic == true,
                    Name = string.Format("{0} {1} {2} #{3}", inventoryData.Card.Set.Release.Year, inventoryData.Card.Set.Release.Brand.Name, inventoryData.Card.Set.Name == "Base" ? "" : inventoryData.Card.Set.Name, inventoryData.Card.CardNumber),
                    People = cardPeopleData.Select(x => new Person { Id = x.Person.Id, Identifier = x.Person.Identifier, Name = x.Person.ToString() }).ToList()
                }
            };

            return inventoryItem;
        }
        public InventoryItem Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(InventoryItem inventoryItem)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, InventoryItem inventoryItem)
        {
            throw new MethodUnsupportedException();
        }
    }
}
