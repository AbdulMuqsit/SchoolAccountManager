using System.Windows.Controls;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;
using SchoolAccountManager.WPF.View;

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
            PrintCommand = new RelayCommand(Print);
        }

        public RelayCommand PrintCommand { get; set; }

        private void Print()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(new PrintPaymentView(), "Receipt");
            }
        }
    }
}