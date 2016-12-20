using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Minor.Dag18.TestTemplate.Data.Entities;

namespace Minor.Dag18.TestTemplate.Data.DAL
{
    public abstract class BaseRepository<T, K> : IRepository<T, K>, IDisposable
{
    protected DatabaseContext context;

    public BaseRepository()
    {
        context = new DatabaseContext();
    }    

    public abstract T Find(K id);    

    public abstract IEnumerable<T> FindAll();

    public abstract IEnumerable<T> FindBy(Expression<Func<T, bool>> filter);

    public abstract void Update(T item);

    public abstract void Insert(T item);

    public abstract void Delete(T item);

    public virtual void InsertRange(IEnumerable<T> items)
    {
        foreach(var item in items)
        {
            Insert(item);
        }
    }

    public virtual void SaveChanges()
    {
        context.SaveChanges();
    }    

    public virtual void Dispose()
    {
        context.Dispose();
    }
}
}
