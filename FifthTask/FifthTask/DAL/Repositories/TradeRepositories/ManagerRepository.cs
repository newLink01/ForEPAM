using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FifthTask.DAL.Entities;
using System.Data.Entity;
namespace FifthTask.DAL.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        TradeEntities context;
        public ManagerRepository()
        {
            context = new TradeEntities();
        }

        public Manager CreateStandaloneElement() {
            return new Manager();
        }

        public IEnumerable<Manager> GetAll()
        {
            return context.Managers;
        }
        public Manager GetElement(int id)
        {
            return context.Managers.Find(id);
        }
        public void Create(Manager item)
        {
            context.Managers.Add(item);
        }
        public void Update(Manager item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Manager man = context.Managers.Find(id);
            if (man != null)
            {

                foreach (var c in context.Sales)
                {
                    if (c.Manager == man.ManagerId)
                    {
                        context.Sales.Remove(c);
                    }
                }

                context.Managers.Remove(man);
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