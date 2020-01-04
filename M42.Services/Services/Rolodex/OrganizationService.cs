using System.Collections.Generic;

namespace M42.Rolodex
{
    public class OrganizationService : IService<Organization>
    {
        public OrganizationService()
        {
            // need to inject the E/F
        }
        public List<Organization> Get()
        {
            return new List<Organization>();
        }
        public Organization Get(int id)
        {
            return new Organization { Id = 1, Identifier = "TestPlayer" };
        }
        public Organization Get(string identifier)
        {
            return new Organization { Id = 1, Identifier = "TestPlayer" };
        }
        public void Post(Organization organization)
        {
            
        }
        public void Put(int id, Organization organization)
        {
            return;
        }
    }
}
