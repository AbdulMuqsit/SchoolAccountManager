using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class AddInvoiceViewModel : ViewModelBase
    {
        public Invoice Invoice { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        //no pun intended
        public RelayCommand GoHomeCommand { get; set; }
        public AddInvoiceViewModel()
        {
            SaveCommand = new RelayCommand(() => Repository.Invoices.Add(Invoice));
            CancelCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.InvoiceViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
        }
    }
}