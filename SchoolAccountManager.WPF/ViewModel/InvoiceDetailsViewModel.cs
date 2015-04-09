using System.Windows.Controls;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;
using SchoolAccountManager.WPF.View;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class InvoiceDetailsViewModel:ViewModelBase
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

        public RelayCommand PrintCommand { get; set; }
        public InvoiceDetailsViewModel()
        {
            Invoice = new Invoice();
            PrintCommand = new RelayCommand(Print);
        }

        private void Print()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(new PrintInvoiceView(), "Invoice");
            }
        }
    }
}