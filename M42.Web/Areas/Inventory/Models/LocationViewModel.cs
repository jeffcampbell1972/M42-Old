using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Inventory;
using M42.SportsCards;

namespace M42.Web.Inventory
{
    public class LocationViewModel : BaseVM
    {

        public LocationViewModel(IService<Location> locationService, int id)
        {
            Location = locationService.Get(id);
        }
        public Location Location { get; set; }
    }
}
