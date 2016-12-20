using Minor.Dag19.WebApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebApiDemo.DAL
{
    public interface IRepository<T,K>
    {
        IEnumerable<T> FindAll();
        void Insert(T item);
        T FindBy(K id);
        void Delete(K id);
    }
}
