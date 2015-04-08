using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class AddPaymentViewModel : ViewModelBase
    {
        public Payment Payment { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        //no pun intended
        public RelayCommand GoHomeCommand { get; set; }
        public AddPaymentViewModel()
        {
            SaveCommand = new RelayCommand(() => Repository.Payments.Add(Payment));
            CancelCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.InvoiceViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
        }
    }
}