using System;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class AddPaymentViewModel : ViewModelBase
    {
        private Payment _payment;

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

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        //no pun intended
        public RelayCommand GoHomeCommand { get; set; }
        public AddPaymentViewModel()
        {
            Payment = new Payment();
            SaveCommand = new RelayCommand(() =>
            {
                Repository.Payments.Add(Payment);
                Payment = new Payment();
            });
            CancelCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.PaymentsViewModel));
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
        }
    }
}