using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAccountManager.WPF.Infrastructure;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public RelayCommand PaymentButtonCommand { get; private set; }
        public RelayCommand InvoiceButtonCommand { get; private set; }

    }
}
