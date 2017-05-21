using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ZSPA.Db
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ZSPADbContext dbCtx;

        public Repository(ZSPADbContext context)
        {
            dbCtx = context;
        }

        public virtual void Add(TEntity entity)
        {
            dbCtx.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            dbCtx.Set<TEntity>().Attach(entity);
            properties.ToList().ForEach(property => dbCtx.Entry(entity).Property(property).IsModified = true);
        }

        public virtual void Update(TEntity entity)
        {
            dbCtx.Set<TEntity>().Attach(entity);
            dbCtx.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Updates(IEnumerable<TEntity> entities, params Expression<Func<TEntity, object>>[] properties)
        {
            entities.ToList().ForEach(entity =>
            {
                dbCtx.Set<TEntity>().Attach(entity);
                properties.ToList().ForEach(property => dbCtx.Entry(entity).Property(property).IsModified = true);
            });
        }

        public virtual void Updates(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(entity =>
            {
                dbCtx.Set<TEntity>().Attach(entity);
                dbCtx.Entry(entity).State = EntityState.Modified;
            });
        }

        public virtual TEntity Get(TKey id)
        {
            return dbCtx.Set<TEntity>().Find(id);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> @where)
        {
            return dbCtx.Set<TEntity>().FirstOrDefault(@where);
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> @where)
        {
            return dbCtx.Set<TEntity>().Where(@where);
        }

        public virtual IQueryable<TEntity> Table
        {
            get { return dbCtx.Set<TEntity>(); }
        }

        public virtual void SaveChanges()
        {
            dbCtx?.SaveChanges();
        }

        public virtual void Dispose()
        {
            dbCtx?.Dispose();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbCtx.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            dbCtx.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbCtx.Set<TEntity>().RemoveRange(entities);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbCtx.Set<TEntity>().ToList();
        }

        public virtual long GetCounts()
        {
            return dbCtx.Set<TEntity>()
                   .LongCount();
        }

        public virtual long GetCounts(Expression<Func<TEntity, bool>> countByCriteria)
        {
            return dbCtx.Set<TEntity>()
                   .LongCount(countByCriteria);
        }

        public virtual IEnumerable<TEntity> GetOrderByDescending<T>(Expression<Func<TEntity, T>> orderBy, int count)
        {
            return dbCtx.Set<TEntity>()
                   .OrderByDescending(orderBy)
                   .Take(count);
        }

        public virtual IEnumerable<TEntity> GetPageByDescending<T>(Expression<Func<TEntity, T>> orderBy, int pageIndex, int pageSize)
        {
            int numberOfRecordsToSkip = (pageIndex - 1) * pageSize;
            return dbCtx.Set<TEntity>()
                   .OrderByDescending(orderBy)
                   .Skip(numberOfRecordsToSkip)
                   .Take(pageSize);
        }

        public virtual IEnumerable<TEntity> GetOrderByAscending<T>(Expression<Func<TEntity, T>> orderBy, int count)
        {
            return dbCtx.Set<TEntity>()
                   .OrderBy(orderBy)
                   .Take(count);
        }

        public virtual IEnumerable<TEntity> GetPageByAscending<T>(Expression<Func<TEntity, T>> orderBy, int pageIndex, int pageSize)
        {
            int numberOfRecordsToSkip = (pageIndex - 1) * pageSize;
            return dbCtx.Set<TEntity>()
                   .OrderBy(orderBy)
                   .Skip(numberOfRecordsToSkip)
                   .Take(pageSize);
        }
    }
}