using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Models
{
    public class MotorAssessorReport : IEntity
    {
        public int Id { get; set; }
        public string Insurance { get; set; }
        public string Client { get; set; }
        public string ClaimNo { get; set; }
        public string Vehicle { get; set; }
        public string DateInspected { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RegistrationNo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool IsRetired { get; set; }
    }
}
