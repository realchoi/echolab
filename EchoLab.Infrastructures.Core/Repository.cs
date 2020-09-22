using EchoLab.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EchoLab.Infrastructures.Core
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
        where TDbContext : EFContext
    {
        protected Repository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual TDbContext DbContext { get; set; }

        public IUnitOfWork UnitOfWork => DbContext;

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        /// <summary>
        /// 新增（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        /// <summary>
        /// 更新（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Remove(TEntity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        /// <summary>
        /// 删除（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Remove(entity));
        }
    }


    public abstract class Repository<TEntity, TKey, TDbContext> : Repository<TEntity, TDbContext>,
        IRepository<TEntity, TKey> where TEntity : Entity, IAggregateRoot where TDbContext : EFContext
    {
        protected Repository(TDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据 Id 获取对象
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        /// <summary>
        /// 根据 Id 获取对象（异步）
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            // return await DbContext.FindAsync<TEntity>(id, cancellationToken);
            // 上述使用方法报错，详情见：https://stackoverflow.com/questions/55758059/get-error-entity-type-course-is-defined-with-a-single-key-property-but-2-va
            return await DbContext.FindAsync<TEntity>(new object[] {id}, cancellationToken);
        }

        /// <summary>
        /// 根据不同的条件获取单个对象
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <returns></returns>
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        /// <summary>
        /// 根据不同的条件获取单个对象（异步）
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        /// <summary>
        /// 根据不同的条件获取对象集合
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <returns></returns>
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().Where(expression).ToList();
        }

        /// <summary>
        /// 根据不同的条件获取对象集合（异步）
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 根据 Id 删除对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(TKey id)
        {
            var query = DbContext.Find<TEntity>(id);
            if (query == null) return false;
            DbContext.Remove(query);
            return true;
        }

        /// <summary>
        /// 根据 Id 删除对象（异步）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var query = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (query == null) return false;
            DbContext.Remove(query);
            return true;
        }
    }
}