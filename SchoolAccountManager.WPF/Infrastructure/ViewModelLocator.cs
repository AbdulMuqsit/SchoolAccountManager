using System.Runtime.Serialization.Formatters;
using SchoolAccountManager.WPF.ViewModel;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; set; }
        public HomeViewModel HomeViewModel { get; set; }

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            HomeViewModel = new HomeViewModel();
        }
    }
}