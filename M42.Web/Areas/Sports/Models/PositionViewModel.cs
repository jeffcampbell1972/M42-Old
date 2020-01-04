using M42.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;

namespace M42.Web.Sports
{
    public class PositionViewModel : BaseVM
    {
        public PositionViewModel(IService<Position> positionService, int positionId, string viewOption = "")
        {
            Position = positionService.Get(positionId);

            DisplayName = Position.Name;
            DetailsView = "~/Areas/Sports/Views/Positions/_PositionDetailsView.cshtml";

            AddMenuItem("Players", viewOption == "" || viewOption == "Players", "Franchises", "Details", positionId, "Players", "Sports", "~/Areas/Sports/Views/Positions/_PositionPeopleView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Position Position { get; set; }
    }
}
