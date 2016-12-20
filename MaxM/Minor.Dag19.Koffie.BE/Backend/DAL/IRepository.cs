using System.Collections.Generic;

namespace Backend.DAL
{
    public interface IRepository<T, K> where T : class
    {
        T GetById(K id);
        IEnumerable<T> GetAll();
        void Insert(T item);
        void Update(T item);
        void Delete(K id);
    }
}
