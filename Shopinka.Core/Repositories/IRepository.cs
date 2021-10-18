using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopinka.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdAsync(int id);
        IEnumerable<TEntity> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        void AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}
