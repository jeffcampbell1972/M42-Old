using System;
using System.Collections.Generic;
using System.Text;

namespace M42
{    
    public interface IService<T>
    {
        public List<T> Get();
        public T Get(int id);
        public T Get(string identifier);
        public void Post(T t);
        public void Put(int id, T t);
    }
}
