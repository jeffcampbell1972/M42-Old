using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class SeasonViewModel : BaseVM
    {
        public SeasonViewModel(IService<Season> seasonService, int seasonId, string viewOption = "")
        {
            Season = seasonService.Get(seasonId);

            DisplayName = Season.Name;
            DetailsView = "~/Areas/Sports/Views/Seasons/_SeasonDetailsView.cshtml";

            AddMenuItem("Results", viewOption == "" || viewOption == "Results", "Seasons", "Details", seasonId, "Results", "Sports", "~/Areas/Sports/Views/Seasons/_SeasonStandingsView.cshtml");
            AddMenuItem("Playoffs", viewOption == "Playoffs", "Seasons", "Details", seasonId, "Playoffs", "Sports", "~/Areas/Sports/Views/Seasons/_SeasonPlayoffsView.cshtml");
            AddMenuItem("Awards", viewOption == "Awards", "Seasons", "Details", seasonId, "Awards", "Sports", "~/Areas/Sports/Views/Seasons/_SeasonAwardsView.cshtml");

            if (Season.HallOfFamers.Count > 0)
            {
                AddMenuItem("Hall of Fame Class", viewOption == "HOF", "Seasons", "Details", seasonId, "HOF", "Sports", "~/Areas/Sports/Views/Seasons/_SeasonHallOfFameView.cshtml");
            }
            if (Season.Draft != null)
            {
                AddMenuItem("Draft", false, "Seasons", "Details", seasonId, "Draft", "Sports", "~/Areas/Sports/Views/Seasons/_SeasonDraftView.cshtml");

                if (viewOption != "" && viewOption.Length >= 5 && viewOption.Substring(0, 5) == "Draft")
                {
                    foreach (var draftRound in Season.Draft.Rounds)
                    {
                        string draftRoundViewOption = string.Format("DraftRound{0}", draftRound.Number);

                        // if "Draft" selected, display the first round of the draft
                        if (viewOption == "Draft" && draftRound.Number == 1)
                        {
                            viewOption = draftRoundViewOption;
                        }

                        if (viewOption == draftRoundViewOption)
                        {
                            SelectedDraftRound = draftRound;
                        }

                        AddMenuItem(draftRound.Label, viewOption == draftRoundViewOption, "Seasons", "Details", seasonId, draftRoundViewOption, "Sports", "~/Areas/Sports/Views/Seasons/_SeasonDraftRoundView.cshtml");
                    }
                }
            }

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public Season Season { get; set; }

        public DraftRound SelectedDraftRound { get; set; }
    }
}
