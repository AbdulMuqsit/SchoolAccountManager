using System.Windows;
using System.Windows.Controls;
using SchoolAccountManager.Entities;
using SchoolAccountManager.WPF.Infrastructure;
using SchoolAccountManager.WPF.View;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class InvoiceDetailsViewModel : ViewModelBase
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

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition(){Width = new GridLength()});
            var column = new ColumnDefinition {Width = new GridLength()};
            grid.ColumnDefinitions.Add(column);
            var btn = new Button
            {
                Content = "Print",
                Width = 70,
                Height = 30,
                Margin = new Thickness(50),
                HorizontalAlignment = HorizontalAlignment.Left
                ,VerticalAlignment = VerticalAlignment.Top
            };

            Grid.SetColumn(btn, 1);
            var print = new PrintInvoiceView
            {

                Height = 1000,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Border =
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

                    printDialog.PrintVisual(print.Border, "Invoice");
                }
            });
            var window = new Window { Content = grid, SizeToContent = SizeToContent.WidthAndHeight };

            window.ShowDialog();
        }

    }
}