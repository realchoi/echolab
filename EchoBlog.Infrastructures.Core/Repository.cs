using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Core
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot where TDbContext : EFContext
    {
        public Repository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual TDbContext DbContext { get; set; }

        public IUnitOfWork UnitOfWork => DbContext;

        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual bool Remove(TEntity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Remove(entity));
        }
    }


    public abstract class Repository<TEntity, TKey, TDbContext> : Repository<TEntity, TDbContext>, IRepository<TEntity, TKey> where TEntity : Entity, IAggregateRoot where TDbContext : EFContext
    {
        public Repository(TDbContext dbContext) : base(dbContext)
        {

        }

        public virtual bool Delete(TKey id)
        {
            var query = DbContext.Find<TEntity>(id);
            if (query != null)
            {
                DbContext.Remove(query);
                return true;
            }
            return false;
        }

        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var query = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (query != null)
            {
                DbContext.Remove(query);
                return true;
            }
            return false;
        }

        public virtual TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }
    }
}
