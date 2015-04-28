using System.Windows;
using System.Windows.Controls;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;
using SchoolAccountManager.WPF.View;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class PaymentDetailsViewModel : ViewModelBase
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
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            var column = new ColumnDefinition { Width = new GridLength() };
            grid.ColumnDefinitions.Add(column);
            var btn = new Button
            {
                Content = "Print",
                Width = 70,
                Height = 30,
                Margin = new Thickness(50),
                HorizontalAlignment = HorizontalAlignment.Left
                ,
                VerticalAlignment = VerticalAlignment.Top
            };

            Grid.SetColumn(btn, 1);
            var print = new PrintPaymentView
            {

                Height = 1000,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Grid =
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 730,
                    Height = 1000,
                }
            };
            Grid.SetColumn(print, 0);
            grid.Children.Add(print);
            grid.Children.Add(btn);
            btn.Click += ((s, e) =>
            {
                var printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {

                    printDialog.PrintVisual(print.Grid, "Receipt");
                }
            });
            var window = new Window { Content = grid, SizeToContent = SizeToContent.WidthAndHeight };

            window.ShowDialog();
            //var printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    var print = new PrintPaymentView();
            //    print.UpdateLayout();
            //    printDialog.PrintVisual(print, "Receipt");
            //}
        }
    }
}