using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using SchoolAccountManager.Entities;

namespace SchoolAccountManager.EF
{
    public class EfRepository : IRepository
    {
        public SchoolAccountManagerDbContext Context
        {
            get;
            set;
        }
        public EfRepository()
        {
            Context = new SchoolAccountManagerDbContext();

            Payments = new EfRepository<Payment>(Context);
            Invoices = new EfRepository<Invoice>(Context);
            if (!Context.Payments.Any())
            {
                Context.Payments.AddRange(new List<Payment>
                {
                    new Payment
                    {
                        StudentName = "Brian Furk",
                        BankName = "National Bank of Utopia",
                        DateTime = DateTime.Now,
                        Description = "Wow Wow",
                        Amount = 3000000,
                        Class = "A"
                    },
                    new Payment
                    {
                        StudentName = "Adam Franco",
                        BankName = "Abc Bank Ltd",
                        DateTime = DateTime.Now,
                        Description = "Very much thanks",
                        Amount = 483,
                        Class = "3C"
                    },
                    new Payment
                    {
                        StudentName = "Larry White",
                        BankName = "Good Bank Ltd",
                        DateTime = DateTime.Now,
                        Description = " Good Deed",
                        Amount = 123,
                        Class = "3B"
                    },
                    new Payment
                    {
                        StudentName = "Nich Potter",
                        BankName = "Some Bank Ltd",
                        DateTime = DateTime.Now,
                        Description = "Good Thanks much",
                        Amount = 231,
                        Class = "5A"
                    }
                });
                Context.SaveChanges();
            }
            if (!Context.Invoices.Any())
            {
                Context.Invoices.AddRange(new List<Invoice>
                    {
                        new Invoice
                        {
                            Name = "Kurt Renoyld",
                            DateTime = DateTime.Now,
                            Item = "Wow Wow",
                            Amount = 3000000,
                            Quantity = 23
                        },
                        new Invoice
                        {
                            Name = "Alfred James",
                            DateTime = DateTime.Now,
                            Item = "something",
                            Amount = 483,
                            Quantity = 235
                        },
                        new Invoice
                        {
                            Name = "Harry Kobian",
                            DateTime = DateTime.Now,
                            Item = "Stationary",
                            Amount = 123,
                            Quantity = 233
                        },
                        new Invoice
                        {
                            Name = "Alfred James",
                            DateTime = DateTime.Now,
                            Item = "Well",
                            Amount = 231,
                            Quantity = 223
                        }
                    });
                Context.SaveChanges();
            }
        }

        public EfRepository<Payment> Payments { get; private set; }
        public EfRepository<Invoice> Invoices { get; private set; }
    }

    public class EfRepository<T> where T : class
    {
        public EfRepository(SchoolAccountManagerDbContext context)
        {
            Context = context;
        }

        protected SchoolAccountManagerDbContext Context { get; set; }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public void Remove(T item)
        {
            Context.Set<T>().Remove(item);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            T item = Get(id);
            Remove(item);
        }

        public void Edit(int id, T item)
        {
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expressioin)
        {
            return Context.Set<T>().Where(expressioin);
        }
    }
}