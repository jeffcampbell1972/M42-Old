using System;
using System.Collections.Generic;
using System.Text;

namespace M42.SportsCards
{
    public interface IReleaseYearService
    {
        public ReleaseYear GetReleaseYear(string identifier);
    }
}
