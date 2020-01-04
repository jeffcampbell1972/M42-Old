using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class FranchiseViewModel : BaseVM
    {
        public FranchiseViewModel(IService<Franchise> franchiseService, int franchiseId, string viewOption = "")
        {
            Franchise = franchiseService.Get(franchiseId);

            DisplayName = Franchise.Name;
            DetailsView = "~/Areas/Sports/Views/Franchises/_FranchiseDetailsView.cshtml";

            AddMenuItem("Schedule", viewOption == "" || viewOption == "Schedule", "Franchises", "Details", franchiseId, "Schedule", "Sports", "~/Areas/Sports/Views/Franchises/_FranchiseCurrentSeasonView.cshtml");
            AddMenuItem("Team History", viewOption == "Teams", "Franchises", "Details", franchiseId, "Teams", "Sports", "~/Areas/Sports/Views/Franchises/_FranchiseTeamsView.cshtml");
            AddMenuItem("Hall of Famers", viewOption == "HOFers", "Franchises", "Details", franchiseId, "HOFers", "Sports", "~/Areas/Sports/Views/Franchises/_FranchiseHOFersView.cshtml");
            AddMenuItem("Playoffs", viewOption == "Playoffs", "Franchises", "Details", franchiseId, "Playoffs", "Sports", "~/Areas/Sports/Views/Franchises/_FranchisePlayoffsView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Franchise Franchise { get; set; }
    }
}
