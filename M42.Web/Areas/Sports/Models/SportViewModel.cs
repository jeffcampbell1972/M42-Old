using M42.Models;
using M42.Sports;
using System.Linq;

namespace M42.Web.Sports
{
    public class SportViewModel : BaseVM
    {
        public SportViewModel(IService<Sport> sportService, int sportId, string viewOption = "")
        {
            Sport = sportService.Get(sportId);

            DisplayName = Sport.Name;
            DetailsView = "~/Areas/Sports/Views/Sports/_SportDetailsView.cshtml";

            AddMenuItem("Leagues", viewOption == "" || viewOption == "Leagues", "Sports", "Details", sportId, "Leagues", "Sports", "~/Areas/Sports/Views/Sports/_SportLeaguesView.cshtml");
            AddMenuItem("Halls of Fame", viewOption == "HOF", "Sports", "Details", sportId, "HOF", "Sports", "~/Areas/Sports/Views/Sports/_SportHOFsView.cshtml");
            AddMenuItem("Positions", viewOption == "Positions", "Sports", "Details", sportId, "Positions", "Sports", "~/Areas/Sports/Views/Sports/_SportPositionsView.cshtml");
            AddMenuItem("Defunct Leagues", viewOption == "Defunct", "Sports", "Details", sportId, "Defunct", "Sports", "~/Areas/Sports/Views/Sports/_SportInactiveLeaguesView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Sport Sport { get; set; }
    }
}
