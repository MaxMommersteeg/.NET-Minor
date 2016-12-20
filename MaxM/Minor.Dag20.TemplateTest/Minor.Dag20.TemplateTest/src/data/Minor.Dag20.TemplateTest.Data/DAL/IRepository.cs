using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag20.TemplateTest.Data.DAL
{
    interface IRepository<TEntity, TKey>
    {
    IEnumerable<TEntity> FindAll();

    IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

    TEntity Find(TKey id);

    void Insert(TEntity item);

    void InsertRange(IEnumerable<TEntity> items);

    void Update(TEntity item);

    void UpdateRange(IEnumerable<TEntity> items);

    void Delete(TEntity item);

    void DeleteRange(IEnumerable<TEntity> items);
    }
}
