using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M42.SportsCards
{
    public class PersonService : IService<Person>
    {
        M42Context _m42;
        public PersonService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Person> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Person Get(int id)
        {
            var personData = GetPerson(id);
            var cardsData = _m42.CardPeople
                .Include(x => x.Card)
                .Include(x => x.Card.Set)
                .Include(x => x.Card.Set.Release)
                .Include(x => x.Card.Set.Release.Brand)
                .Include(x => x.Card.Set.Release.League)
                .Where(x => x.PersonId == id)
                .Select(x => x.Card)
                .Distinct()
                .OrderBy(x => x.Set.Release.Year)
                .ThenBy(x => x.Set.Release.Brand.Name)
                .ThenBy(x => x.Set.Name)
                .ThenBy(x => x.CardNumber)
                .ToList();

            var person = new Person
            {
                Id = personData.Id,
                Identifier = personData.Identifier,
                Name = personData.ToString() ,
                Cards = cardsData.Select(x => new Card { Id = x.Id, Name = string.Format("{0} {1} {2} #{3}", x.Set.Release.Year, x.Set.Release.Brand.Name, x.Set.Name == "Base"? "" : x.Set.Name, x.CardNumber) }).ToList() ,
                NumCards = cardsData.Count()
            };

            return person;
        }
        public Person Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Person person)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Person person)
        {
            throw new MethodUnsupportedException();
        }

        #region Get methods

        public M42.Data.Models.Person GetPerson(int id)
        {
            var personData = _m42.People
               .SingleOrDefault(x => x.Id == id);

            if (personData == null)
            {
                throw new EntityNotFoundException();
            }

            return personData;
        }
        #endregion

        #region Build methods

 
        #endregion
    }
}
