using DoctorConsult.Core.Entity.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DoctorConsult.Core.Entity.Model
{
    public class PatientsProblemPageForDoctorModel : BaseModel
    {
        [Required]
        public string ProblemSummary { get; set; }
        [Required]
        public string ProblemDetails { get; set; }
        public string FilePath { get; set; }
        public string PreviousProblemReportFile { get; set; }
    }
}
