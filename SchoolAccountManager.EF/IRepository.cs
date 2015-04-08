using SchoolAccountManager.Entities;

namespace SchoolAccountManager.EF
{
    public interface IRepository
    {
        EfRepository<Payment> Payments { get; }
        EfRepository<Invoice> Invoices { get; }
    }
}