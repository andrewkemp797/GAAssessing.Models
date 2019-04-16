using GAAssessing.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Configuration
{
    public class MotorAssessorReportConfig : EntityTypeConfiguration<MotorAssessorReport>
    {
        public MotorAssessorReportConfig()
        {
            HasOptional(o => o.VehicleCondition)
                .WithRequired(r => r.MotorAssessorReport)
                .WillCascadeOnDelete(true);
        }
    }
}
