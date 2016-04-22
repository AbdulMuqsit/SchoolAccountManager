using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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
        public void Print()
        {

            var printDialog = new System.Windows.Forms.PrintDialog();
            var doc = new PrintDocument();
            printDialog.Document = doc;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

        }


        public void ProvideContent(object sender, PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;


            const String titleLineOne = "God's Wisdom Internationl";
            const string titleLineTwo = "School";

            const string underLine = "--------------------------------------------";
            int startX = 4;
            const int startY = 4;
            int offset = 20;

            graphics.DrawString(titleLineOne, new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX + 20, startY + offset);
            offset += 20;
            graphics.DrawString(titleLineTwo, new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX + 120, startY + offset);
            offset += 35;
            graphics.DrawString("Issue Date : " + DateTime.Now.ToShortDateString(), new Font("Courier New", 7),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 10;

            graphics.DrawString(underLine, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 10;
            graphics.DrawString("Name            -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString("Date            -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString("Description     -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString("Class           -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString("Bank            -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString("Amount          -", new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 10;
            graphics.DrawString(underLine, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);

            startX = 150;
            offset = 95;

            graphics.DrawString(Payment.StudentName, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            if (Payment.DateTime != null)
                graphics.DrawString(Payment.DateTime.Value.ToShortDateString(), new Font("Courier New", 8),
                    new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString(Payment.Description, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString(Payment.Class, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            graphics.DrawString(Payment.BankName, new Font("Courier New", 8),
                new SolidBrush(Color.Black), startX, startY + offset);
            offset += 20;
            if (Payment.Amount != null)
                graphics.DrawString(String.Format(new System.Globalization.CultureInfo("ig-NG"), "{0:C}", Payment.Amount.Value), new Font("Courier New", 8),
                    new SolidBrush(Color.Black), startX, startY + offset);

        }
    }
}