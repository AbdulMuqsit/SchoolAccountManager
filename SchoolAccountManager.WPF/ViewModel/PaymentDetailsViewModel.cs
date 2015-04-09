using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class PaymentDetailsViewModel:ViewModelBase
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

        public PaymentDetailsViewModel()
        {
            Payment = new Payment();
        }
    }
}