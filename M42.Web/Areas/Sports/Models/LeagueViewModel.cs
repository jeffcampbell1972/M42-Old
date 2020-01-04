using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class LeagueViewModel : BaseVM
    {
        public LeagueViewModel(IService<League> leagueService, int leagueId, string viewOption = "")
        {
            League = leagueService.Get(leagueId);

            DisplayName = League.Abbreviation;
            DetailsView = "~/Areas/Sports/Views/Leagues/_LeagueDetailsView.cshtml";

            AddMenuItem("Franchises", viewOption == "" || viewOption == "Franchises", "Leagues", "Details", leagueId, "Franchises", "Sports", "~/Areas/Sports/Views/Leagues/_LeagueFranchisesView.cshtml");
            //AddMenuItem("Standings", viewOption == "Standings", "Leagues", "Details", leagueId, "Standings", "Sports", "~/Areas/Sports/Views/Leagues/_LeagueStandingsView.cshtml");
            AddMenuItem("Season History", viewOption == "Season", "Leagues", "Details", leagueId, "Season", "Sports", "~/Areas/Sports/Views/Leagues/_LeagueSeasonsView.cshtml");
            AddMenuItem("Champions", viewOption == "Champions", "Leagues", "Details", leagueId, "Champions", "Sports", "~/Areas/Sports/Views/Leagues/_LeagueChampionsView.cshtml");

            //if (League.Draft != null)
            //{
            //    AddMenuItem("Draft", false, "Leagues", "Details", leagueId, "Draft", "Sports", "~/Areas/Sports/Views/Leagues/_LeagueDraftView.cshtml");

            //    if (viewOption != "" && viewOption.Substring(0, 5) == "Draft")
            //    {
            //        foreach (var draftRound in League.Draft.Rounds)
            //        {
            //            string draftRoundViewOption = string.Format("DraftRound{0}", draftRound.Number);

            //            // if "Draft" selected, display the first round of the draft
            //            if (viewOption == "Draft" && draftRound.Number == 1)
            //            {
            //                viewOption = draftRoundViewOption;
            //            }

            //            if (viewOption == draftRoundViewOption)
            //            {
            //                SelectedDraftRound = draftRound;
            //            }

            //            AddMenuItem(draftRound.Label, viewOption == draftRoundViewOption, "Leagues", "Details", leagueId, draftRoundViewOption, "Sports", "~/Areas/Sports/Views/Leagues/_LeagueDraftRoundView.cshtml");
            //        }
            //    }
            //}
            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public League League { get; set; }

        public DraftRound SelectedDraftRound { get; set; }
    }
}
