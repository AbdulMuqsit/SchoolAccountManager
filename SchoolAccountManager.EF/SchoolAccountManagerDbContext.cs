using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAccountManager.Entities;

namespace SchoolAccountManager.EF
{
    public class SchoolAccountManagerDbContext:DbContext
    {
        public SchoolAccountManagerDbContext()
            : base("SchoolAccountManagerDbC")
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
