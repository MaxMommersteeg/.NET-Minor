using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository
{
    public abstract class BaseRepository<Entity, Key, Context> : IRepository<Entity, Key>, IDisposable
        where Context : DbContext
        where Entity : class
    {
        protected Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(Context context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract DbSet<Entity> GetDbSet();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract Key GetKeyFrom(Entity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter)
        {
            return GetDbSet().Where(filter).ToList();
        }

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>whether record exists in database</returns>
        public virtual bool Exists(Key id)
        {
            return GetDbSet().SingleOrDefault(a => GetKeyFrom(a).Equals(id)) != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Entity Find(Key id)
        {
            return GetDbSet().Single(a => GetKeyFrom(a).Equals(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Entity> FindAll()
        {
            return GetDbSet().ToList(); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual Key Insert(Entity item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return GetKeyFrom(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Update(Entity item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(Key id)
        {
            var toRemove = Find(id);
            _context.Remove(toRemove);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int Count()
        {
            return FindAll().Count();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}
