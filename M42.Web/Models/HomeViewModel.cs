using M42.Data.Initializer;

namespace M42.Models
{
    public class HomeViewModel
    {
       
        public HomeViewModel(IDatabaseService databaseService)
        {
            if (databaseService.IsSeeded())
            {
                WelcomeMessage = "Data is seeded.";
                ShowSeedDataLink = false;
            }
            else

            {
                WelcomeMessage = "Data is not seeded.";
                ShowSeedDataLink = true;
            }
        }
        public string WelcomeMessage { get; set; }
        public bool ShowSeedDataLink { get; set; }
    }
}
