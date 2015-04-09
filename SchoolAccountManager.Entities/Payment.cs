using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SchoolAccountManager.Entities.Annotations;

namespace SchoolAccountManager.Entities
{
    public class Payment:INotifyPropertyChanged
    {
        private string _studentName;
        private double? _amount;
        private string _bankName;
        private string _description;
        private DateTime? _dateTime;
        private string _class;
        public int Id { get; set; }

        public string StudentName
        {
            get { return _studentName; }
            set
            {
                if (value == _studentName) return;
                _studentName = value;
                OnPropertyChanged();
            }
        }

        public double? Amount
        {
            get { return _amount; }
            set
            {
                if (value.Equals(_amount)) return;
                _amount = value;
                OnPropertyChanged();
            }
        }

        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (value == _bankName) return;
                _bankName = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DateTime
        {
            get { return _dateTime; }
            set
            {
                if (value.Equals(_dateTime)) return;
                _dateTime = value;
                OnPropertyChanged();
            }
        }

        public string Class
        {
            get { return _class; }
            set
            {
                if (value == _class) return;
                _class = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}