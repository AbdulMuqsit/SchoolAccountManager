using System;
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
        private string _searchText;
        public ViewModelBase CurrentChildViewModel { get { return ViewModelLocator.InvoiceDetailsViewModel; } set { } }
        public ObservableCollection<Invoice> Invoices
        {
            get
            {
                if (String.IsNullOrWhiteSpace(SearchText) && Repository.Invoices.GetAll().Count() != _invoices.Count)
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
            if (Invoices.Any())
            {
                Invoice = Invoices[0];

            }
            SwitchToAddNewCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.AddInvoiceViewModel));
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

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText) return;

                _searchText = value;
                OnPropertyChanged();
                Search();

            }
        }

        private void Search()
        {
            Invoices = string.IsNullOrWhiteSpace(SearchText) ? new ObservableCollection<Invoice>(Repository.Invoices.GetAll()) : new ObservableCollection<Invoice>(Repository.Invoices.Where(e => e.Name.ToLower().Contains(SearchText.ToLower())));
        }
    }
}