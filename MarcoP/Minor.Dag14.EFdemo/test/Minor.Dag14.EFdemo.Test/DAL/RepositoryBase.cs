using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag14.EFdemo.Test.DAL
{
    public abstract class RepositoryBase<T,K, Context> : IRepository<T, K>
        where T : class
        where Context : DbContext
    {
        protected Context _context;

        public RepositoryBase(Context context)
        {
            _context = context;
        }

        protected abstract DbSet<T> GetDbSet();
        protected abstract K GetKeyFrom(T item);


        public virtual T Find(K id)
        {
            return GetDbSet().Single(b => GetKeyFrom(b).Equals(id));
        }

        public virtual IEnumerable<T> FindAll()
        {
            return GetDbSet().ToList();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            return GetDbSet().Where(filter).ToList();
        }

        public virtual void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            T oldItem = GetDbSet().FirstOrDefault(b => GetKeyFrom(b).Equals(GetKeyFrom(item)));
            _context.Remove(oldItem);
            _context.SaveChanges();
        }
    }
}
