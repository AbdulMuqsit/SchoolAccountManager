﻿using System;
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