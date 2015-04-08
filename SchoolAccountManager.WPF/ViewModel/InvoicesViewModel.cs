using System.Collections.ObjectModel;
using System.ComponentModel;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class InvoicesViewModel : ViewModelBase
    {
        private ObservableCollection<Payment> _payments;
        private Payment _payment;

        public ObservableCollection<Payment> Payments
        {
            get { return _payments; }
            set
            {
                if (Equals(value, _payments)) return;
                _payments = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SwitchToAddNewCommand { get; set; }
        public InvoicesViewModel()
        {
            Refresh();
            SwitchToAddNewCommand = new RelayCommand(() =>Navigator.SwitchView(this,ViewModelLocator.AddPaymentViewModel));
        }

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