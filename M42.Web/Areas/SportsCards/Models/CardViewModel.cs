using M42.Models;
using M42.SportsCards;
using System.Linq;

namespace M42.Web.SportsCards
{
    public class CardViewModel : BaseVM
    {
        public CardViewModel(IService<Card> cardService, int cardId, string viewOption = "")
        {
            Card = cardService.Get(cardId);

            DisplayName = Card.Name;
            DetailsView = "~/Areas/SportsCards/Views/Cards/_CardDetailsView.cshtml";        

            //foreach (var set in Card.Sets)
            //{
            //    AddMenuItem(set.Name, (viewOption == "" && set.IsBaseSet) || viewOption == set.Identifier, "Cards", "Details", cardId, set.Identifier, "SportsCards", "~/Areas/SportsCards/Views/Cards/_CardSetView.cshtml");
            //}

            //var selectedMenuItem = Menu.MenuItems.Single(x => x.IsSelected);

            //SelectedMenuItemView = selectedMenuItem.PartialView;
            //SetToView = Card.Sets.Single(x => x.Identifier == selectedMenuItem.ViewOption);
        }
        public Card Card { get; set; }
        public Set SetToView { get; set; }
    }
}
