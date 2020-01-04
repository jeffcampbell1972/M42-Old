using M42.Models;
using M42.SportsCards;
using System.Linq;

namespace M42.Web.SportsCards
{
    public class ReleaseViewModel : BaseVM
    {
        public ReleaseViewModel(IService<Release> releaseService, int releaseId, string viewOption = "")
        {
            Release = releaseService.Get(releaseId);

            DisplayName = Release.Name;
            DetailsView = "~/Areas/SportsCards/Views/Releases/_ReleaseDetailsView.cshtml";        

            foreach (var set in Release.Sets)
            {
                AddMenuItem(set.Name, (viewOption == "" && set.IsBaseSet) || viewOption == set.Identifier, "Releases", "Details", releaseId, set.Identifier, "SportsCards", "~/Areas/SportsCards/Views/Releases/_ReleaseSetView.cshtml");
            }

            var selectedMenuItem = Menu.MenuItems.Single(x => x.IsSelected);

            SelectedMenuItemView = selectedMenuItem.PartialView;
            SetToView = Release.Sets.Single(x => x.Identifier == selectedMenuItem.ViewOption);
        }
        public Release Release { get; set; }
        public Set SetToView { get; set; }
    }
}
