using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.SportsCards;

namespace M42.Web.SportsCards
{
    public class PersonViewModel : BaseVM
    {
        public PersonViewModel(IService<Person> personService, int personId, string viewOption = "")
        {
            Person = personService.Get(personId);

            DisplayName = Person.Name;
            DetailsView = "~/Areas/SportsCards/Views/People/_PersonDetailsView.cshtml";

            AddMenuItem("Cards", true, "People", "Details", personId, "Player", "SportsCards", "~/Areas/SportsCards/Views/People/_PersonCardsView.cshtml");

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;

            NumColumns = (Person.NumCards / 20) + 1;

        }
        public Person Person { get; set; }
        public int NumColumns { get; set; }
    }
}
