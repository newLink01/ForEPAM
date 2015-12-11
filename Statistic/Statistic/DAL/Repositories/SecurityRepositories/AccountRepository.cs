using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statistic.DAL.Entities;
using System.Data.Entity;
namespace Statistic.DAL.Repositories.SecurityRepositories
{
    public class AccountRepository : IRepository<Account>
    {
        SecurityEntities context;
        public AccountRepository() {
            this.context = new SecurityEntities();
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts;
        }
        public Account GetElement(int id)
        {
            return context.Accounts.Find(id);
        }
        public void Create(Account item)
        {
            context.Accounts.Add(item);
        }
        public void Update(Account item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Account account = context.Accounts.Find(id);
            if (account != null)
            {
                context.Accounts.Remove(account);
            }




        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }








    }
}