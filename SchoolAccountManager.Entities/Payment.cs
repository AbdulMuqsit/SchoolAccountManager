using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAccountManager.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Amount { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Class { get; set; }
    }
}
