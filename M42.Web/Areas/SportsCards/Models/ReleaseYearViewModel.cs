using M42.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.SportsCards;

namespace M42.Web.SportsCards
{
    public class ReleaseYearViewModel : BaseVM
    {
        public ReleaseYearViewModel(IReleaseYearService releaseYearService, string identifier, string viewOption = "")
        {
            ReleaseYear = releaseYearService.GetReleaseYear(identifier);

            DisplayName = string.Format("{0} {1} Card Releases", ReleaseYear.Year.ToString(), ReleaseYear.Sport.Name);
            DetailsView = "~/Areas/SportsCards/Views/ReleaseYears/_ReleaseYearDetailsView.cshtml";

            //AddMenuItem("Release Years", viewOption == "" || viewOption == "ReleaseYears", "Sports", "Details", identifier, "ReleaseYears", "Sports", "~/Areas/SportsCards/Views/ReleaseYears/_ReleaseYearReleasesView.cshtml");

            //SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public ReleaseYear ReleaseYear { get; set; }
    }
}
