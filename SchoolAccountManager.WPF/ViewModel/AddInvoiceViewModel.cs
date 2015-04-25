using System;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class AddInvoiceViewModel : ViewModelBase
    {
        private Invoice _invoice;

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

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        //no pun intended
        public RelayCommand GoHomeCommand { get; set; }
        public AddInvoiceViewModel()
        {
            Invoice = new Invoice ();
            SaveCommand = new RelayCommand(() =>
            {
                Repository.Invoices.Add(Invoice);
                Invoice = new Invoice();
            });
            CancelCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.InvoiceViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
        }
    }
}