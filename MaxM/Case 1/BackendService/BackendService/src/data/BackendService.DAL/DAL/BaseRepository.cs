using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BackendService.DAL.DAL
{
     public abstract class BaseRepository<T, Key, Context>
    : IRepository<T, Key>, IDisposable
        where Context : DbContext
        where T : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
        protected abstract DbSet<T> GetDbSet();
        protected abstract Key GetKeyFrom(T item);

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            return GetDbSet().Where(filter);
        }

        public virtual void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual int Count()
        {
            return GetDbSet().Count();
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}