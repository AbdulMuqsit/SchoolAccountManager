using SchoolAccountManager.WPF.ViewModel;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            HomeViewModel = new HomeViewModel();
        }

        public MainViewModel MainViewModel { get; set; }
        public HomeViewModel HomeViewModel { get; set; }
    }
}