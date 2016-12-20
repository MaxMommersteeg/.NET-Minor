using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Minor.Dag16.DAL.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
        TEntity Find(TKey id);

        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
