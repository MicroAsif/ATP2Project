using DoctorConsult.Core.Entity.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string Status { get; set; }

        [ForeignKey("PatientProfile")]
        public int PatintId { get; set; }
        public PatientProfileModel PatientProfile { get; set; }
        [ForeignKey("DoctorProfileModel")]
        public int DoctorId { get; set; }
        public DoctorProfileModel DoctorProfileModel { get; set; }



    }
}
