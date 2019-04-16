using GAAssessing.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Repositories
{
    public class Repository : IRepository
    {
        protected readonly IAssessingContext Context;

        public Repository(IAssessingContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = Context.Set<TEntity>();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.Where(x => !x.IsRetired);
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include)).AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.Where(x => !x.IsRetired);
        }

        public void AttachEntity<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Context.Set<TEntity>().Attach(entity);
        }

        public void AttachEntity<TEntity>(ICollection<TEntity> entities) where TEntity : class, IEntity
        {
            foreach (TEntity entity in entities)
                Context.Set<TEntity>().Attach(entity);
        }

        public void ModifyState<TEntity>(TEntity entity, EntityState state) where TEntity : class, IEntity
        {
            Context.Entry(entity).State = state;
        }

        public void ModifyState<TEntity>(ICollection<TEntity> entities, EntityState state) where TEntity : class, IEntity
        {
            foreach (TEntity entity in entities)
                Context.Entry(entity).State = state;
        }

        public virtual IList<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual IList<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IList<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual IList<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return GetQueryable(null, orderBy, skip, take, includes).ToList();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable(null, orderBy, skip, take, includes).ToListAsync();
        }

        public virtual IList<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter, orderBy, skip, take, includes).ToList();
        }

        public virtual async Task<IList<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            return await GetQueryable(filter, orderBy, skip, take, includes).ToListAsync();
        }

        public virtual TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class, IEntity
        {
            return GetQueryable(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class, IEntity
        {
            return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst<TEntity>(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
           where TEntity : class, IEntity
        {
            return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            where TEntity : class, IEntity
        {
            return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById<TEntity>(Guid id)
            where TEntity : class, IEntity
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual Task<TEntity> GetByIdAsync<TEntity>(Guid id)
            where TEntity : class, IEntity
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable(filter).AnyAsync();
        }

        public virtual void Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            
            entity.DateCreated = DateTime.UtcNow;

            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Create<TEntity, TChildEntity>(TEntity entity, ICollection<TChildEntity> childEntities)
            where TEntity : class, IEntity
            where TChildEntity : class, IEntity
        {
            //attach navigation property to context, to avoid adding duplicate records when specifying relationship
            foreach (TChildEntity value in childEntities)
                Context.Entry(value).State = EntityState.Unchanged;

            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Context.Set<TEntity>().Attach(entity);
            Context.SetModified(entity);
        }

        public virtual void Update<TEntity, TChildEntity>(TEntity entity, ICollection<TChildEntity> childEntities)
            where TEntity : class, IEntity
            where TChildEntity : class, IEntity
        { 
            foreach (TChildEntity value in childEntities)
                Context.Set<TChildEntity>().Attach(value);

            Context.Set<TEntity>().Attach(entity);
            Context.SetModified(entity);
        }

        public virtual void SoftDelete<TEntity>(Guid id)
            where TEntity : class, IEntity
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            SoftDelete(entity);
        }

        public virtual void SoftDelete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            entity.IsRetired = true;
            Update(entity);
        }

        public virtual int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw ThrowEnhancedValidationException(e);
            }
        }

        public virtual Task<int> SaveAsync()
        {
            try
            {
                return Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                throw ThrowEnhancedValidationException(e);
            }
        }

        protected virtual DbEntityValidationException ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            IEnumerable<string> errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            return new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }
    }
}
