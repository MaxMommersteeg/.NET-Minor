using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BackendService.DAL.DAL
{
    public interface IRepository<TEntity, TKey> : IDisposable
    {
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        void Insert(TEntity item);

        int Count();
    }
}
