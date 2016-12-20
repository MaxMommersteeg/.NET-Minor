using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using Microsoft.EntityFrameworkCore;


namespace Minor.Dag21.CAS.BackEnd.DAL.DAL
{
     public abstract class BaseRepository<T, Key, Context>
    : IRepository<T, Key>,
        IDisposable
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

        public virtual T Find(Key id)
        {
            return GetDbSet().Single(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IEnumerable<T> FindAll()
        {
            return GetDbSet();
        }

        public virtual void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void InsertRange(IEnumerable<T> items)
        {
            _context.AddRange(items);
            _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<T> items)
        {
            _context.UpdateRange(items);
            _context.SaveChanges();
        }

        public virtual void Delete(Key id)
        {
            var toRemove = Find(id);
            _context.Remove(toRemove);
            _context.SaveChanges();
        }

        public virtual int Count()
        {
            return FindAll().Count();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}