using M42.Models;
using M42.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M42.Web.Inventory
{
    public class ContainerViewModel : BaseVM
    {
        public ContainerViewModel(IService<Container> containerService, int containerId, string viewOption = "")
        {
            Container = containerService.Get(containerId);

            DisplayName = Container.Name;
            DetailsView = "~/Areas/Inventory/Views/Containers/_ContainerDetailsView.cshtml";

            int numInventoryItems = Container.Contents.Count();
            int maxItemSize = Container.Contents.Select(x => x.Name.Length).ToList().OrderByDescending(x => x).First();

            int charPerLine = 250;
            int itemsPerColumn = 22;

            NumContentsPageColumns = charPerLine / maxItemSize;


            int maxPageSize = NumContentsPageColumns * itemsPerColumn;

            int numPages = Container.NumInventory / maxPageSize;
            if (Container.NumInventory % maxPageSize > 0)
            {
                numPages += 1;
            }
            if (viewOption == "")
            {
                viewOption = "Page1";
            }

            for (int pageNumber = 1; pageNumber <= numPages; pageNumber++)
            {
                string pageLabel = string.Format("Page {0}", pageNumber);
                string pageIdentifier = string.Format("Page{0}", pageNumber);

                AddMenuItem(pageLabel, viewOption == pageIdentifier, "Containers", "Details", containerId, pageIdentifier, "Inventory", "~/Areas/Inventory/Views/Containers/_ContainerContentsView.cshtml");
            }
            var selectedMenuItem = Menu.MenuItems.SingleOrDefault(x => x.IsSelected);

            if (selectedMenuItem != null)
            {

                int pageToView = Int32.Parse(viewOption.Replace("Page", ""));
                int index = (pageToView - 1) * maxPageSize;
                int pageSize = maxPageSize;
                if (pageToView == numPages)
                {
                    pageSize = Container.Contents.Count - index;
                }

                SelectedMenuItemView = selectedMenuItem.PartialView;
                ContentsPage = Container.Contents.GetRange(index, pageSize);
            }
            else
            {
                ContentsPage = new List<InventoryItem>();
            }
        }
        public Container Container { get; set; }

        public List<InventoryItem> ContentsPage { get; set; }
        public int NumContentsPageColumns { get; set; }
    }
}
