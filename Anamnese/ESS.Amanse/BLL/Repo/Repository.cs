using EFCore.BulkExtensions;
using ESS.Amanse.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESS.Amanse.BLL.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        protected AmanseHomeContext dbContext;

        public Repository(AmanseHomeContext context)
        {
            dbContext = context;
            DbSet = dbContext.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
            dbContext.Set<TEntity>().Add(entity);
        }
        public virtual void AddOrUpdate(TEntity entity)
        {
            var entry = dbContext.Entry(entity);
            switch (entry.State)
            {
                case EntityState.Detached:
                    dbContext.Add(entity);
                    break;
                case EntityState.Modified:
                    dbContext.Update(entity);
                    break;
                case EntityState.Added:
                    dbContext.Add(entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void AddRelatedObjects(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }
        public virtual TEntity DetachEntity(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual List<TEntity> DetachEntities(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.DetachEntity(entity);
            }
            return entities;
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
        }
        public virtual void InsertBulk(List<TEntity> entities)
        {
            dbContext.BulkInsert(entities);
        }
        public virtual void DeleteBulk(List<TEntity> entities)
        {
            dbContext.BulkDelete(entities);
        }
        public virtual void UpdateBulk(List<TEntity> entities)
        {
            dbContext.BulkUpdate(entities);
        }
        public virtual void InsertOrUpdateBulk(List<TEntity> entities)
        {
            dbContext.BulkInsertOrUpdate(entities);
        }
        public virtual void UpdateBulkExcludeProp(List<TEntity> entities, BulkConfig config)
        {
            dbContext.BulkUpdate(entities, config);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbContext.Set<TEntity>();
        }
        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
        public virtual TEntity GetById(long id)
        {
            return DbSet.Find(id);
        }
        protected IEnumerable<TEntity> GetAllWithIncludes(
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();
            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = query.OrderBy(orderBy);
            return query.ToList();
        }
        public virtual void Remove(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
            Save();
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                if (dbContext.Entry(entity).State == EntityState.Detached)
                    dbContext.Attach(entity);

                dbContext.Entry(entity).State = EntityState.Modified;
                DbSet.Update(entity);
            }
            catch
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                DbSet.Update(entity);
            }
        }

        public virtual void MergeAndUpdate(TEntity oldEntity, TEntity newEntity)
        {
            var updatedObj = CheckUpdateObject(oldEntity, newEntity);

            dbContext.Entry(oldEntity).CurrentValues.SetValues(updatedObj);
        }

        private object CheckUpdateObject(object originalObj, object updateObj)
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                if (property.GetValue(updateObj, null) == null)
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                    .GetValue(originalObj, null));
                }
            }
            return updateObj;
        }
        public virtual void Save()
        {
            dbContext.SaveChanges();
        }

        public virtual void UndoChanges()
        {
            // Undo the changes of the all entries. 
            foreach (EntityEntry entry in dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    // Under the covers, changing the state of an entity from  
                    // Modified to Unchanged first sets the values of all  
                    // properties to the original values that were read from  
                    // the database when it was queried, and then marks the  
                    // entity as Unchanged. This will also reject changes to  
                    // FK relationships since the original value of the FK  
                    // will be restored. 
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).SingleOrDefault();
        }
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = DbSet.Include(include);
            }
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = query.OrderBy(orderBy);
            return await query.ToListAsync();
        }

        public IQueryable<TResult> GetIncludewithFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector);
            }
            else
            {
                return query.Select(selector);
            }
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }
        public virtual void InsertOrUpdate(TEntity entity, params Expression<Func<TEntity, object>>[] columns)
        {
            //if (entity.Id.ToString() == Guid.Empty.ToString() || entity.Id.ToString() == "0")
            //{
            //    dbContext.Entry(entity).State = EntityState.Added;
            //}
            //else
            //{
            try
            {
                if (dbContext.Entry(entity).State == EntityState.Detached)
                    dbContext.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }

            if (columns != null)
                foreach (var columnname in columns)
                {
                    dbContext.Entry(entity).Property(columnname).IsModified = false;
                }
            //  }
        }

        public virtual async Task<IQueryable<TEntity>> ExecuteRawSqlWithParameter(string query, params object[] parameters)
        {
            return await Task.Run(() => DbSet.FromSqlRaw(query, parameters));
        }
        public virtual async Task<IQueryable<TEntity>> ExecuteRawSql(string query)
        {

            return await Task.Run(() => DbSet.FromSqlRaw(query));
        }
        public virtual async Task<int> ExecuteSqlRawAsync(string query)
        {

            return await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(query));
        }
        public virtual AmanseHomeContext GetDbContext()
        {

            return dbContext;
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            IIncludableQueryable<TEntity, object> query = null;

            if (includes.Length > 0)
            {
                query = DbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? DbSet : (IQueryable<TEntity>)query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, int pageNo, int pageSize)
        {
            return await (dbContext.Set<TEntity>().Where(predicate).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync());
        }

    }
}
