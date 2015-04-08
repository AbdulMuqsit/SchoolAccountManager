using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public RelayCommand PaymentButtonCommand { get; private set; }
        public RelayCommand InvoiceButtonCommand { get; private set; }

        public HomeViewModel()
        {
            PaymentButtonCommand = new RelayCommand(()=> Navigator.SwitchView(ViewModelLocator.PaymentsViewModel));
            InvoiceButtonCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.InvoiceViewModel));

        }
    }
}