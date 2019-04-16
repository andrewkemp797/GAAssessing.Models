using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Context
{
    public class AssessingContextFactory : IDbContextFactory<AssessingContext>
    {
        public AssessingContext Create()
        {
            return new AssessingContext(ConfigurationManager.ConnectionStrings["GAAssessing"].ConnectionString);
        }
    }
}
