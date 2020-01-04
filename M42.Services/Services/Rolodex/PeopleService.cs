using System.Collections.Generic;

namespace M42.Rolodex
{
    public class PeopleService : IService<Person>
    {
        public PeopleService()
        {
            // need to inject the E/F
        }
        public List<Person> Get()
        {
            return new List<Person>();
        }
        public Person Get(int id)
        {
            return new Person { Id = 1, Identifier = "TestPlayer" };
        }
        public Person Get(string identifier)
        {
            return new Person { Id = 1, Identifier = "TestPlayer" };
        }
        public void Post(Person person)
        {

        }
        public void Put(int id, Person person)
        {
            return;
        }
    }
}
