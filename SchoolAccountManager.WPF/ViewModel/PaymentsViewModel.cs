using System;
using System.Collections.ObjectModel;
using System.Linq;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class PaymentsViewModel : ViewModelBase
    {
        private Payment _payment;
        private ObservableCollection<Payment> _payments;
        private string _searchText;

        public PaymentsViewModel()
        {
            Refresh();
            if (Payments.Any())
            {
                Payment = Payments[0];
            }
            SwitchToAddNewCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.AddPaymentViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
        }

        public ViewModelBase CurrentChildViewModel
        {
            get { return ViewModelLocator.PaymentDetailsViewModel; }
            set { }
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

        public ObservableCollection<Payment> Payments
        {
            get
            {
                if (String.IsNullOrWhiteSpace(SearchText) && Repository.Payments.GetAll().Count() != _payments.Count)
                {
                    Refresh();
                }

                return _payments;
            }
            set
            {
                if (Equals(value, _payments)) return;
                _payments = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SwitchToAddNewCommand { get; set; }

        public RelayCommand GoHomeCommand { get; set; }

        public Payment Payment
        {
            get { return _payment; }
            set
            {
                if (Equals(value, _payment)) return;
                _payment = value;
                OnPropertyChanged();
            }
        }

        private void Search()
        {
            Payments = string.IsNullOrWhiteSpace(SearchText)
                            ? new ObservableCollection<Payment>(Repository.Payments.GetAll())
                            : new ObservableCollection<Payment>(
                                Repository.Context.Payments.Local.Where(e =>
                                {
                                    if (e.StudentName != null)
                                    {
                                        return e.StudentName.ToLower().Contains(SearchText.ToLower());
                                    }
                                    return false;
                                }));
        }

        private void Refresh()
        {
            Payments = new ObservableCollection<Payment>(Repository.Payments.GetAll());
        }
    }
}