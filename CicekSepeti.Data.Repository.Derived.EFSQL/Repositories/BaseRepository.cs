using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using CicekSepeti.Core.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Derived.EFSQL.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>
        :
        IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        protected readonly DbContext _context;
        public readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            EntityEntry<TEntity> insertItem = _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return insertItem.Entity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedTime = DateTime.Now;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual bool Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedTime = DateTime.Now;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return true;
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(m => m.IsDeleted == false).Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }
        public virtual async Task<IList<TEntity>> GetListAsync()
        {
            var list = await _dbSet.Where(m => m.IsDeleted == false).AsNoTracking().ToListAsync();
            return list;
        }
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(m => m.IsDeleted == false).AsNoTracking().CountAsync(predicate);
        }
        public virtual async Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var list = await _dbSet.Where(m => m.IsDeleted == false).Where(predicate).AsNoTracking().ToListAsync();
            return list.AsQueryable();
        }

        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicates.Any())
            {
                foreach (var item in predicates)
                {
                    query = query.Where(item);
                }
            }
            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }
    }
}
