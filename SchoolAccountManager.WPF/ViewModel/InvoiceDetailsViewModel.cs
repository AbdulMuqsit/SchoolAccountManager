using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;

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

        public InvoiceDetailsViewModel()
        {
            Invoice = new Invoice();
        }
    }
}