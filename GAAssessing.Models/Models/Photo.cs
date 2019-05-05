using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoBase64 { get; set; }

        public int MotorAssessorReportId { get; set; }
        public virtual MotorAssessorReport MotorAssessorReport { get; set; }
    }
}
