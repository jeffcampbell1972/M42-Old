using M42.Models;
using M42.Sports;
using System.Linq;

namespace M42.Web.SportsCards
{
    public class SportViewModel : BaseVM
    {
        public SportViewModel(IService<Sport> sportService, int sportId, string viewOption = "")
        {
            Sport = sportService.Get(sportId);

            DisplayName = Sport.Name;
            DetailsView = "~/Areas/SportsCards/Views/Sports/_SportDetailsView.cshtml";

            AddMenuItem("Release Years", viewOption == "" || viewOption == "ReleaseYears", "Sports", "Details", sportId, "ReleaseYears", "Sports", "~/Areas/SportsCards/Views/Sports/_SportReleaseYearView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Sport Sport { get; set; }
    }
}
