using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Minor.Dag38.HelloAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace Minor.Dag38.HelloAPI.DAL.DAL
{
     public abstract class BaseRepository<Entity, Key, Context>
    : IRepository<Entity, Key>,
        IDisposable
        where Context : DbContext
        where Entity : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
        protected abstract DbSet<Entity> GetDbSet();
        protected abstract Key GetKeyFrom(Entity item);

        public virtual IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter)
        {
            return GetDbSet().Where(filter);
        }

        public virtual Entity Find(Key id)
        {
            return GetDbSet().Single(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IEnumerable<Entity> FindAll()
        {
            return GetDbSet();
        }

        public virtual void Insert(Entity item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void InsertRange(IEnumerable<Entity> items)
        {
            _context.AddRange(items);
            _context.SaveChanges();
        }

        public virtual void Update(Entity item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<Entity> items)
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