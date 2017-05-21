using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZSPA.Db
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

        void Updates(IEnumerable<TEntity> entities);

        void Updates(IEnumerable<TEntity> entities, params Expression<Func<TEntity, object>>[] properties);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        long GetCounts();

        long GetCounts(Expression<Func<TEntity, bool>> countByCriteria);

        IEnumerable<TEntity> GetOrderByDescending<T>(Expression<Func<TEntity, T>> orderBy, int count);

        IEnumerable<TEntity> GetPageByDescending<T>(Expression<Func<TEntity, T>> orderBy, int pageIndex, int pageSize);

        IEnumerable<TEntity> GetOrderByAscending<T>(Expression<Func<TEntity, T>> orderBy, int count);

        IEnumerable<TEntity> GetPageByAscending<T>(Expression<Func<TEntity, T>> orderBy, int pageIndex, int pageSize);

        TEntity Get(TKey id);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Table { get; }

        void SaveChanges();

        void Dispose();
    }
}