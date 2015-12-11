using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statistic.DAL.Entities;
using System.Data.Entity;
namespace Statistic.DAL.Repositories.SecurityRepositories
{
    public class RoleRepository : IRepository<Role>
    {
         SecurityEntities context;
        public RoleRepository() {
            this.context = new SecurityEntities();
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles;
        }
        public Role GetElement(int id)
        {
            return context.Roles.Find(id);
        }
        public void Create(Role item)
        {
            context.Roles.Add(item);
        }
        public void Update(Role item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Role role = context.Roles.Find(id);
            if (role != null) {
                foreach (var account in context.Accounts) {
                    if (account.Role == role.RoleId) {
                        context.Accounts.Remove(account);
                    }
                }
                context.Roles.Remove(role); }
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