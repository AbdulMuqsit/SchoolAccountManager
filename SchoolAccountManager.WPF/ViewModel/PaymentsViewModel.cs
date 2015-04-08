using System.Collections.ObjectModel;
using System.Linq;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class PaymentsViewModel : ViewModelBase
    {
        private ObservableCollection<Payment> _payments;
        private Payment _payment;
        public ViewModelBase CurrentChildViewModel { get; set; }

        public ObservableCollection<Payment> Payments
        {
            get
            {
                if (Repository.Payments.GetAll().Count() != _payments.Count)
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
        public PaymentsViewModel()
        {
            Refresh();
            CurrentChildViewModel = ViewModelLocator.PaymentDetailsViewModel;
            Payment = Payments[0];
            SwitchToAddNewCommand = new RelayCommand(() => Navigator.SwitchView(this, ViewModelLocator.AddPaymentViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));

        }
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

        private void Refresh()
        {
            Payments = new ObservableCollection<Payment>(Repository.Payments.GetAll());
        }
    }
}