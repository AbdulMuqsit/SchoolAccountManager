using SchoolAccountManager.WPF.ViewModel;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        public ViewModelBase MainViewModel { get; set; }

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
        }
    }
}