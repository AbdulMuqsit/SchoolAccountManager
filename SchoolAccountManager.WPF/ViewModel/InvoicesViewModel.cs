using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class InvoicesViewModel : ViewModelBase
    {
        private ObservableCollection<Invoice> _invoices;
        private Invoice _invoice;
        public ViewModelBase CurrentChildViewModel { get; set; }
        public ObservableCollection<Invoice> Invoices
        {
            get
            {
                if (Repository.Invoices.GetAll().Count() != _invoices.Count)
                {
                    Refresh();
                }
                return _invoices;
            }
            set
            {
                if (Equals(value, _invoices)) return;
                _invoices = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SwitchToAddNewCommand { get; set; }
        public InvoicesViewModel()
        {
            Refresh();
            CurrentChildViewModel = ViewModelLocator.InvoiceDetailsViewModel;
            Invoice = Invoices[0];
            SwitchToAddNewCommand = new RelayCommand(() => Navigator.SwitchView(this, ViewModelLocator.AddPaymentViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));

        }

        public Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                if (Equals(value, _invoice)) return;
                _invoice = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand GoHomeCommand { get; set; }

        private void Refresh()
        {
            Invoices = new ObservableCollection<Invoice>(Repository.Invoices.GetAll());
        }
    }
}