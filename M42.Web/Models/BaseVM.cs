using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M42.Models
{
    public class BaseVM
    {
        // user rights would be controlled here
        public bool IsAdmin { get; set; }
        public string Title { get; set; }
        public string DisplayName { get; set; }

        public PeerNavigatorVM PeerNavigator { get; set; }
        public DetailsVM Details { get; set; }
        public MenuVM Menu { get; set; }

        public string SelectedMenuItemView { get; set; }
        public string DetailsView { get; set; }

        public BaseVM()
        {
            IsAdmin = true;
            PeerNavigator = new PeerNavigatorVM();

            Menu = new MenuVM
            {
                MenuItems = new List<MenuItemVM>()
            };
            Details = new DetailsVM
            {
                Items = new List<DetailsItemVM>()
            };
        }
        protected string GetShowHideValue (string value, string showHideValue)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            return showHideValue;
        }
        public void AddDetailsItem(string label, string value)
        {
            Details.Items.Add(new DetailsItemVM
            {
                Label = label,
                Value = value
            });
        }
        public void AddMenuItem(string text, bool isSelected, string controller, string action, int id, string viewOption, string area, string partialView)
        {
            Menu.MenuItems.Add(new MenuItemVM
            {
                Identifier = String.Format("{0}MenuItem", text) ,
                CssClass = isSelected ? "selectedMenuItem" : "",
                Text = text ,
                Action = action,
                Controller = controller,
                Id = id,
                ViewOption = viewOption,
                Area = area ,
                IsSelected = isSelected ,
                PartialView = partialView
            });
        }

    }
}