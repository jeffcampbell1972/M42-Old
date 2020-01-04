using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Models;
using M42.Sports;

namespace M42.Web.Sports
{
    public class HallOfFameViewModel : BaseVM
    {
        public HallOfFameViewModel(IService<HallOfFame> hallOfFameService, int hallOfFameId, string viewOption = "")
        {
            HallOfFame = hallOfFameService.Get(hallOfFameId);

            DisplayName = HallOfFame.Name;
            DetailsView = "~/Areas/Sports/Views/HallsOfFame/_HallOfFameDetailsView.cshtml";

            if (HallOfFame.Members.Count > 0)
            {

                string startDecade = string.Format("{0}0s", HallOfFame.InauguralYear.ToString().Substring(0, 3));

                string selectedDecade = "";
                string selectedClass = "";

                if (viewOption == "")
                {
                    viewOption = startDecade;
                    selectedDecade = startDecade;
                    selectedClass = HallOfFame.InauguralYear.ToString();
                }
                else if (viewOption.Length == 4)
                {
                    selectedDecade = string.Format("{0}0s", viewOption.Substring(0, 3));
                    selectedClass = viewOption;
                }
                else if (viewOption == startDecade)
                {
                    selectedDecade = viewOption;
                    selectedClass = HallOfFame.InauguralYear.ToString();
                }
                else
                {
                    selectedDecade = viewOption;
                    selectedClass = string.Format("{0}0", viewOption.Substring(0, 3));
                }

                AddMenuItem(startDecade, viewOption == startDecade, "HallsOfFame", "Details", hallOfFameId, startDecade, "Sports", "~/Areas/Sports/Views/HallsOfFame/_HallOfFameClassView.cshtml");

                foreach (var hallOfFameClass in HallOfFame.Classes)
                {
                    int classYear = hallOfFameClass.Year;
                    string classDecade = string.Format("{0}0s", classYear.ToString().Substring(0, 3));
                    if (classYear.ToString().Substring(3, 1) == "0")
                    {
                        AddMenuItem(classDecade, viewOption == classDecade, "HallsOfFame", "Details", hallOfFameId, classDecade, "Sports", "~/Areas/Sports/Views/HallsOfFame/_HallOfFameClassView.cshtml");
                    }
                    if (classDecade == selectedDecade)
                    {
                        AddMenuItem(string.Format("- {0}", classYear), viewOption == classYear.ToString(), "HallsOfFame", "Details", hallOfFameId, classYear.ToString(), "Sports", "~/Areas/Sports/Views/HallsOfFame/_HallOfFameClassView.cshtml");
                    }

                    if (selectedClass == classYear.ToString())
                    {
                        SelectedClass = hallOfFameClass;
                    }
                }
                SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;

            }
        }
        public HallOfFame HallOfFame { get; set; }
        public HallOfFameClass SelectedClass { get; set; }
    }
}
