using System;

namespace SchoolAccountManager.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
    }
}