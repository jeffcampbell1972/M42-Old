using System;
using System.Collections.Generic;
using System.Text;
using M42.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using M42.Sports;

namespace M42.Inventory
{
    public class ContainerService : IService<Container>
    {
        M42Context _m42;
        public ContainerService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Container> Get()
        {
            var containersData = GetContainers();

            var containers = BuildContainers(containersData);

            return containers;
        }
        public Container Get(int id)
        {
            var containerData = GetContainer(id);
            var inventoriesData = GetInventories(id);
            var cardIdsData = GetCardIds(inventoriesData);
            var cardPeopleData = GetCardPeople(cardIdsData);

            var inventoryItems = BuildInventoryItems(inventoriesData, cardPeopleData);

            var container = new Container
            {
               Id = containerData.Id ,
               Identifier = containerData.Identifier ,
               Name = containerData.Name ,
               NumInventory = inventoryItems.Count ,
               ContainerType = new ContainerType 
               { 
                   Id = containerData.ContainerType.Id, 
                   Identifier = containerData.Identifier, 
                   Name = containerData.ContainerType.Name 
               } ,
               Contents = inventoryItems
            };

            return container;
        }
        public Container Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Container container)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Container container)
        {
            throw new MethodUnsupportedException();
        }

        #region Get data
        private List<M42.Data.Models.Container> GetContainers()
        {
            var containersData = _m42.Containers
                .Include(x => x.ContainerType)
                .Include(x => x.Location)
                .OrderBy(x => x.Name).ToList();

            return containersData;
        }
        private M42.Data.Models.Container GetContainer(int id)
        {
            var containerData = _m42.Containers.Include(x => x.ContainerType).Include(x => x.Location).SingleOrDefault(x => x.Id == id);

            if (containerData == null)
            {
                throw new Exception("Invalid Id to Containers provided.");
            }

            return containerData;
        }
        public List<M42.Data.Models.Inventory> GetInventories(int id)
        {
            var inventoriesData = _m42.Inventories
               .Include(x => x.Card)
               .Include(x => x.Card.Set)
               .Include(x => x.Card.Set.Release)
               .Include(x => x.Card.Set.Release.Brand)
               .Include(x => x.Card.Set.Release.League)
               .Where(x => x.ContainerId == id)
               .OrderBy(x => x.Card.Set.Release.Year)
               .ThenBy(x => x.Card.Set.Release.Brand.Name)
               .ThenBy(x => x.Card.Set.Name)
               .ThenBy(x => x.Card.CardNumber)
               .ToList();

            return inventoriesData;
        }
        private List<int> GetCardIds(List<M42.Data.Models.Inventory> inventoriesData)
        {
            var cardIdsData = inventoriesData.Select(x => x.CardId).ToList();

            return cardIdsData;
        }
        private List<M42.Data.Models.CardPerson> GetCardPeople(List<int> cardIdsData)
        {
            var cardPeopleData = _m42.CardPeople
                .Include(x => x.Person)
                .Where(x => cardIdsData.Contains(x.CardId))
                .ToList();

            return cardPeopleData;
        }
        #endregion

        #region Build results
        private List<Container> BuildContainers(List<M42.Data.Models.Container> containersData)
        {
            var containers = containersData.Select(x => new Container
            {
                Id = x.Id,
                Identifier = x.Identifier,
                Name = x.Name,
                ContainerType = new ContainerType { Id = x.ContainerType.Id, Identifier = x.ContainerType.Identifier, Name = x.ContainerType.Name }
            })
            .ToList();

            return containers;
        }
        private List<InventoryItem> BuildInventoryItems(List<M42.Data.Models.Inventory> inventoriesData, List<M42.Data.Models.CardPerson> cardPeopleData)
        {
            var inventoyItems = inventoriesData
                .Select(x => new InventoryItem
                {
                    Id = x.Id,
                    Name = string.Format("{0} {1} {2} #{3} {4}", x.Card.Set.Release.Year, x.Card.Set.Release.Brand.Name, x.Card.Set.Release.League.Abbreviation, x.Card.CardNumber, BuildCardPeople(cardPeopleData, x.CardId))
                })
                .ToList();

            return inventoyItems;
        }
        private string BuildCardPeople(List<M42.Data.Models.CardPerson> cardPeopleData, int cardId)
        {
            var people = cardPeopleData.Where(x => x.CardId == cardId).Select(x => new Person
            {
                Id = x.Person.Id,
                Name = x.Person.ToString()
            })
            .ToList();

            var name = "";
            foreach (var person in people)
            {
                if (name != "")
                {
                    name += "/";
                }
                name += person.Name;
            }

            return name;
        }
        #endregion
    }
}
