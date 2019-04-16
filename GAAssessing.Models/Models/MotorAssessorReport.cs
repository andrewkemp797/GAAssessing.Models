using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Models
{
    public class MotorAssessorReport : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Insurance { get; set; }
        public string Client { get; set; }
        public string ClaimNo { get; set; }
        public string Vehicle { get; set; }
        public DateTimeOffset DateInspected { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RegistrationNo { get; set; }
        public bool IsRetired { get; set; }

        public virtual VehicleCondition VehicleCondition { get; set; }
    }
}
