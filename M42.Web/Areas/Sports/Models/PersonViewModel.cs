using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class PersonViewModel : BaseVM
    {
        public PersonViewModel(IService<Person> personService, int personId, string viewOption = "")
        {
            Person = personService.Get(personId);

            DisplayName = Person.Name;
            DetailsView = "~/Areas/Sports/Views/People/_PersonDetailsView.cshtml";

            if (Person.PlayerTeams.Count > 0)
            {
                if (viewOption == "")
                {
                    viewOption = "Player";
                }
                AddMenuItem("Playing Career", viewOption == "Player", "People", "Details", personId, "Player", "Sports", "~/Areas/Sports/Views/People/_PersonPlayerView.cshtml");
            }
            if (Person.CoachTeams.Count > 0)
            {
                if (viewOption == "")
                {
                    viewOption = "Coach";
                }
                AddMenuItem("Coaching Career", viewOption == "Coach", "People", "Details", personId, "Coach", "Sports", "~/Areas/Sports/Views/People/_PersonCoachView.cshtml");
            }
            if (Person.OwnerTeams.Count > 0)
            {
                if (viewOption == "")
                {
                    viewOption = "Owner";
                }
                AddMenuItem("Ownership Career", viewOption == "Owner", "People", "Details", personId, "Owner", "Sports", "~/Areas/Sports/Views/People/_PersonOwnerView.cshtml");
            }
            if (Person.LeagueCommissionerSeasons.Count > 0)
            {
                if (viewOption == "")
                {
                    viewOption = "Commissioner";
                }
                AddMenuItem("Commissioner Career", viewOption == "Commissioner", "People", "Details", personId, "Commissioner", "Sports", "~/Areas/Sports/Views/People/_PersonExecutiveView.cshtml");
            }

            if (Menu.MenuItems.Count > 0)
            {
                SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
            }
        }
        public Person Person { get; set; }
    }
}
