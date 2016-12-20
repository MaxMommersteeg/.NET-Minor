using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.DagXX.XXX1.DAL.DAL
{
    interface IRepository<TEntity, TKey> 
        : IDisposable
    {
    IEnumerable<TEntity> FindAll();

    IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

    TEntity Find(TKey id);

    int Insert(TEntity item);

    int InsertRange(IEnumerable<TEntity> items);

    int Update(TEntity item);

    int UpdateRange(IEnumerable<TEntity> items);

    int Delete(TKey item);

    int DeleteRange(IEnumerable<TKey> items);

    int Count();
    }
}
