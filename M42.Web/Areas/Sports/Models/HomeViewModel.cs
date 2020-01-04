using System.Collections.Generic;
using M42.Sports;

namespace M42.Web.Sports
{
    public class HomeViewModel
    {
        public HomeViewModel(IService<Sport> sportService)
        {
            Sports = sportService.Get();
        }
        public List<Sport> Sports { get; set; }
    }
}
