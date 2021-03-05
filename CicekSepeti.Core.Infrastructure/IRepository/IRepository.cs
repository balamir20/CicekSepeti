using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Infrastructure.IRepository
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        bool Delete(TEntity entity);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> GetListAsync();

        Task<TEntity> GetByIdAsync(int id);
        Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] include);
    }
}
