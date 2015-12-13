using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FifthTask.DAL.Entities;
namespace FifthTask.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        TradeEntities context;
        public ProductRepository()
        {
            context = new TradeEntities();
        }

        public Product CreateStandaloneElement() {
            return new Product();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }
        public Product GetElement(int id)
        {
            return context.Products.Find(id);
        }
        public void Create(Product item)
        {
            context.Products.Add(item);
        }
        public void Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Product prod = context.Products.Find(id);
            if (prod != null)
            {
                foreach (var c in context.Sales)
                {
                    if (c.Product == prod.ProductId)
                    {
                        context.Sales.Remove(c);
                    }
                }
                context.Products.Remove(prod);
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