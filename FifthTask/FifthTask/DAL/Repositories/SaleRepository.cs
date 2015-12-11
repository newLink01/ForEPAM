using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FifthTask.DAL.Entities;
namespace FifthTask.DAL.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {
        TradeEntities context;
        public SaleRepository()
        {
            this.context = new TradeEntities();
        }

        public IEnumerable<Sale> GetAll()
        {
            return context.Sales;
        }
        public Sale GetElement(int id)
        {
            return context.Sales.Find(id);
        }
        public void Create(Sale item)
        {
            context.Sales.Add(item);
        }
        public void Update(Sale item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Sale sale = context.Sales.Find(id);
            if (sale != null)
            {

                context.Sales.Remove(sale);
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