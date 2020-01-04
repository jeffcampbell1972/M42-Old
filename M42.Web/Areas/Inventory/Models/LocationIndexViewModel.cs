using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Inventory;

namespace M42.Web.Inventory
{
    public class LocationIndexViewModel : BaseVM
    {

        public LocationIndexViewModel(IService<Location> locationService)
        {
            Locations = locationService.Get();
        }
        public List<Location> Locations { get; set; }
    }
}
