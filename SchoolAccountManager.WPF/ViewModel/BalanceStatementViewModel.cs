using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SchoolAccountManager.WPF.Infrastructure;
using SchoolAccountManager.WPF.View;

namespace SchoolAccountManager.WPF.ViewModel
{
    public class BalanceStatementViewModel : ViewModelBase
    {
        private DateTime? _startDate;
        private DateTime? _endDate;
        private double? _totalExpendature;
        private double? _totalIncome;
        private double? _totalProfit;

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (value.Equals(_startDate)) return;
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (value.Equals(_endDate)) return;
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public double? TotalExpendature
        {
            get { return _totalExpendature; }
            set
            {
                if (value.Equals(_totalExpendature)) return;
                _totalExpendature = value;
                OnPropertyChanged();
            }
        }

        public double? TotalIncome
        {
            get { return _totalIncome; }
            set
            {
                if (value.Equals(_totalIncome)) return;
                _totalIncome = value;
                OnPropertyChanged();
            }
        }

        public double? TotalProfit
        {
            get { return _totalProfit; }
            set
            {
                if (value.Equals(_totalProfit)) return;
                _totalProfit = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CalculateProfitCommand { get; set; }
        public RelayCommand GoHomeCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }

        public BalanceStatementViewModel()
        {
            CalculateProfitCommand = new RelayCommand(CalculateProfit);
            GoHomeCommand = new RelayCommand(() => Navigator.SwitchView(ViewModelLocator.HomeViewModel));
            PrintCommand = new RelayCommand(Print);
        }
        private void Print()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(new PrintBalanceStatementView(), "Balance Statement");
            }
        }
        private void CalculateProfit()
        {
            TotalExpendature = Repository.Invoices.Where(e => e.DateTime > StartDate && e.DateTime < EndDate).Sum(e => e.Amount);
            TotalIncome = Repository.Payments.Where(e => e.DateTime > StartDate && e.DateTime < EndDate).Sum(e => e.Amount);
            TotalProfit = TotalIncome - TotalExpendature;

        }
    }
}
