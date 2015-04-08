using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildViewModel;

        public ViewModelBase CurrentChildViewModel
        {
            get { return _currentChildViewModel; }
            set
            {
                if (Equals(value, _currentChildViewModel)) return;
                _currentChildViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentChildViewModel = ViewModelLocator!=null ? ViewModelLocator.HomeViewModel : new HomeViewModel();
        }
    }
}