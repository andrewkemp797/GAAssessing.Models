using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Models
{
    public class VehicleCondition : IEntity
    {
        [ForeignKey("MotorAssessorReport")]
        public int Id { get; set; }
        public int Odometer { get; set; }
        public string Steering { get; set; }
        public string Footbrake { get; set; }
        public string Handbrake { get; set; }
        public string Bodywork { get; set; }
        public string Windscreen { get; set; }
        public string Chassis { get; set; }
        public string Interior { get; set; }
        public string PaintCondition { get; set; }
        public string PaintColour { get; set; }

        public bool AirConditioner { get; set; }
        public bool MagWheels { get; set; }
        public bool Sunroof { get; set; }
        public bool Spotlights { get; set; }
        public bool Towbar { get; set; }
        public bool RunningBoards { get; set; }
        public bool Radio { get; set; }
        public bool Speakers { get; set; }
        public bool CentralLocking { get; set; }
        public bool Immobiliser { get; set; }
        public bool BullBar { get; set; }
        public bool BootSpoiler { get; set; }

        public string GeneralCondition { get; set; }
        public string MissingItems { get; set; }
        public string OldDamage { get; set; }
        public string TyreMake { get; set; }
        public int TyreThreadLF { get; set; }
        public int TyreThreadRF { get; set; }
        public int TyreThreadLR { get; set; }
        public int TyreThreadRR { get; set; }
        public int TyreThreadSpare { get; set; }

        public string VehicleInspectedAt { get; set; }
        public string QuotesObtainedFrom { get; set; }

        public string Remarks { get; set; }

        public bool IsRetired { get; set; }

        public virtual MotorAssessorReport MotorAssessorReport { get; set; }
    }
}
