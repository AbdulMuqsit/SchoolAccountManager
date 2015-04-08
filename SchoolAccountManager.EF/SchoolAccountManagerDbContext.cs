using System.Data.Entity;
using SchoolAccountManager.Entities;

namespace SchoolAccountManager.EF
{
    public class SchoolAccountManagerDbContext : DbContext
    {
        public SchoolAccountManagerDbContext()
            : base("SchoolAccountManagerDbC")
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}