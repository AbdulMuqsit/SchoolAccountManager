using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentChildViewModel
        {
            get
            {
                if (ViewModelLocator == null)
                {
                    return new HomeViewModel();
                }
                return ViewModelLocator.HomeViewModel;
            }
            set { }
        }
    }
}