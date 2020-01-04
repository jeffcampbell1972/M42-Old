using System;
using System.Collections.Generic;
using System.Text;

namespace M42
{
    public interface ISearchService<T>
    {
        public T Get();
        public T Get(T t);
    }
}
