using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Repositories
{
    public interface IRepository
    {
        void AttachEntity<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void AttachEntity<TEntity>(ICollection<TEntity> entities) where TEntity : class, IEntity;

        void ModifyState<TEntity>(TEntity entity, EntityState state) where TEntity : class, IEntity;

        void ModifyState<TEntity>(ICollection<TEntity> entities, EntityState state) where TEntity : class, IEntity;

        IList<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        Task<IList<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        IList<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        Task<IList<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        IList<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity;

        Task<IList<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity;

        IList<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity;

        Task<IList<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity;

        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class, IEntity;

        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            where TEntity : class, IEntity;

        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            where TEntity : class, IEntity;

        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
            where TEntity : class, IEntity;

        TEntity GetById<TEntity>(Guid id)
            where TEntity : class, IEntity;

        Task<TEntity> GetByIdAsync<TEntity>(Guid id)
            where TEntity : class, IEntity;

        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        void Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Create<TEntity, TChildEntity>(TEntity entity, ICollection<TChildEntity> childEntities)
            where TEntity : class, IEntity
            where TChildEntity : class, IEntity;

        void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Update<TEntity, TChildEntity>(TEntity entity, ICollection<TChildEntity> childEntities)
            where TEntity : class, IEntity
            where TChildEntity : class, IEntity;

        void SoftDelete<TEntity>(Guid id)
            where TEntity : class, IEntity;

        void SoftDelete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        int Save();

        Task<int> SaveAsync();
    }
}
