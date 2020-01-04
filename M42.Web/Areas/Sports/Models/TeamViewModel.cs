using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class TeamViewModel : BaseVM
    {
        public TeamViewModel(IService<Team> teamService, int teamId, string viewOption = "")
        {
            Team = teamService.Get(teamId);

            DisplayName = Team.Name;
            DetailsView = "~/Areas/Sports/Views/Teams/_TeamDetailsView.cshtml";

            AddMenuItem("Roster", viewOption == "" || viewOption == "Roster", "Teams", "Details", teamId, "Roster", "Sports", "~/Areas/Sports/Views/Teams/_TeamRosterView.cshtml");
            
            if (Team.RegularSeason.Count > 0)
            {
                AddMenuItem("Results", viewOption == "Schedule", "Teams", "Details", teamId, "Schedule", "Sports", "~/Areas/Sports/Views/Teams/_TeamScheduleView.cshtml");
            }
            if (Team.PlayoffGames.Count > 0)
            {
                AddMenuItem("Playoffs", viewOption == "Playoffs", "Teams", "Details", teamId, "Playoffs", "Sports", "~/Areas/Sports/Views/Teams/_TeamPlayoffsView.cshtml");
            }
            
            AddMenuItem("Draft Picks", viewOption == "DraftPicks", "Teams", "Details", teamId, "DraftPicks", "Sports", "~/Areas/Sports/Views/Teams/_TeamDraftView.cshtml");
            AddMenuItem("Hall of Famers", viewOption == "HallOfFamers", "Teams", "Details", teamId, "HallOfFamers", "Sports", "~/Areas/Sports/Views/Teams/_TeamHOFersView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Team Team { get; set; }
    }
}
