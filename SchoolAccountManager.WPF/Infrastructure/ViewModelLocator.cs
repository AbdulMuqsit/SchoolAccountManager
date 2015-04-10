using System;
using System.ComponentModel;
using System.Windows;
using SchoolAccountManager.WPF.ViewModel;

namespace SchoolAccountManager.WPF.Infrastructure
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                MainViewModel = new MainViewModel();
                HomeViewModel = new HomeViewModel();
                PaymentsViewModel = new PaymentsViewModel();
                InvoiceViewModel = new InvoicesViewModel();
                AddPaymentViewModel = new AddPaymentViewModel();
                AddInvoiceViewModel = new AddInvoiceViewModel();
                InvoiceDetailsViewModel = new InvoiceDetailsViewModel();
                PaymentDetailsViewModel = new PaymentDetailsViewModel();
                BalanceStatementViewModel = new BalanceStatementViewModel();
            }
        }

        public MainViewModel MainViewModel { get; set; }
        public HomeViewModel HomeViewModel { get; set; }
        public PaymentsViewModel PaymentsViewModel { get; set; }
        public InvoicesViewModel InvoiceViewModel { get; set; }
        public AddPaymentViewModel AddPaymentViewModel { get; set; }
        public AddInvoiceViewModel AddInvoiceViewModel { get; set; }
        public InvoiceDetailsViewModel InvoiceDetailsViewModel { get; set; }
        public PaymentDetailsViewModel PaymentDetailsViewModel { get; set; }
        public BalanceStatementViewModel BalanceStatementViewModel { get; set; }
    }
}