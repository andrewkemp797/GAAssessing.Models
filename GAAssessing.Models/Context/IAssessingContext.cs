using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Context
{
    public interface IAssessingContext
    {
        Database Database { get; }
        void SetModified(IEntity entity);
        DbEntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
