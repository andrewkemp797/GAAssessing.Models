using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Context
{
    public class AssessingContext : DbContext, IAssessingContext
    {
        public AssessingContext(string connectionString)
           : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            // Remove pluralised table name convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add all EntityTypeConfigurations
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual void SetModified(IEntity entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
