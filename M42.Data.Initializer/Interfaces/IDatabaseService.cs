using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Data.Initializer
{
    public interface IDatabaseService
    {
        public bool IsSeeded();

        public void SeedDatabase();
    }
}
