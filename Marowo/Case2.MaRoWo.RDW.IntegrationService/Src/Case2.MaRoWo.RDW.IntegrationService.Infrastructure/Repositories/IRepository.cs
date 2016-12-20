using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories {
    public interface IRepository<TEntity, TKey> : IDisposable
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        TEntity Find(TKey id);

        void Insert(TEntity item);

        void Update(TEntity item);

        void Delete(TKey item);
    }
}
