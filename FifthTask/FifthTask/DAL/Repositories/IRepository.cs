using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthTask.DAL.Repositories
{
   public interface IRepository<T> : IDisposable where T:class
    {
       T CreateStandaloneElement();
        IEnumerable<T> GetAll();
        T GetElement(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
