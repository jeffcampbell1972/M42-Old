using M42.Models;
using M42.Inventory;
using System.Collections.Generic;
using System.Linq;

namespace M42.Web.Inventory
{
    public class ContainerIndexViewModel : BaseVM
    {
        public ContainerIndexViewModel(IService<Container> containerService, string viewOption = "")
        {
            var allContainers = containerService.Get();
            DisplayName = "Sports Card Containers";

            Containers = allContainers.Where(x => viewOption == "" || viewOption == "All" || x.ContainerType.Identifier == viewOption).ToList();

            AddMenuItem("All", viewOption == "" || viewOption == "All", "Containers", "Index", 0, "All", "Inventory", "~/Areas/Inventory/Views/Containers/_ContainerIndexView.cshtml");

            var containerTypes = new List<ContainerType>();

            foreach(var container in allContainers)
            {
                var containerType = containerTypes.SingleOrDefault(x => x.Id == container.ContainerType.Id);
                if (containerType == null)
                {
                    containerTypes.Add(container.ContainerType);
                }
            }

            foreach (var containerType in containerTypes)
            {
                AddMenuItem(containerType.Name, viewOption == containerType.Identifier, "Containers", "Index", 0, containerType.Identifier, "Inventory", "~/Areas/Inventory/Views/Containers/_ContainerIndexView.cshtml");
            }

            SelectedMenuItemView = Menu.MenuItems.Single(x => x.IsSelected).PartialView;
        }
        public List<Container> Containers { get; set; }
    }
}
