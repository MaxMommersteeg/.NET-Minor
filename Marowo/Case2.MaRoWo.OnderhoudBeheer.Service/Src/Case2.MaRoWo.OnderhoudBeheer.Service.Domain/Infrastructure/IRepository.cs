using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Infrastructure
{
    public interface IRepository<TEntity, TKey> : IDisposable
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        bool Exists(TKey id);

        TEntity Find(TKey id);

        TKey Insert(TEntity item);

        void Update(TEntity item);

        void Delete(TKey item);
    }
}
