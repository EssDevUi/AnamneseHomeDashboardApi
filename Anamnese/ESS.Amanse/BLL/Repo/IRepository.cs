using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESS.Amanse.BLL.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void AddRelatedObjects(TEntity entity);
        TEntity DetachEntity(TEntity entity);
        List<TEntity> DetachEntities(List<TEntity> entities);
        void AddRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateBulk(List<TEntity> entities);
        void UpdateBulk(List<TEntity> entities);
        void DeleteBulk(List<TEntity> entities);
        void InsertBulk(List<TEntity> entities);
        void UpdateBulkExcludeProp(List<TEntity> entities, BulkConfig config);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void MergeAndUpdate(TEntity oldEntity, TEntity newEntity);
        void Save();
        void UndoChanges();
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        TEntity GetById(long id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        #region Async Methods
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        void InsertOrUpdate(TEntity entity, params Expression<Func<TEntity, object>>[] columns);

        /// <summary>
        /// WARNING ::Use Only when Absolutely nessary 
        /// </summary>
        /// <param name="query">accepts a query</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> ExecuteRawSql(string query);

        /// <summary>
        /// WARNING ::Use Only when Absolutely nessary 
        /// </summary>
        /// <param name="query">accepts a query </param>
        /// <param name="parameters">accepts parameter</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> ExecuteRawSqlWithParameter(string query, params object[] parameters);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
        #endregion
    }
}
