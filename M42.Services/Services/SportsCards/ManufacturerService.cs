using System;
using System.Collections.Generic;
using System.Text;
using M42.Data;

namespace M42.SportsCards
{
    public class ManufacturerService : IService<Manufacturer>
    {
        M42Context _m42;
        public ManufacturerService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Manufacturer> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Manufacturer Get(int id)
        {
            throw new MethodUnsupportedException();
        }
        public Manufacturer Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Manufacturer manufacturer)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Manufacturer manufacturer)
        {
            throw new MethodUnsupportedException();
        }
    }
}
