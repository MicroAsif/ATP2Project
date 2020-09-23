using DoctorConsult.Core.Entity.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DoctorConsult.Core.Entity.Model
{
    public class PatientsConsultModel: BaseModel
    {
        [Required]
        public string ProblemSummary { get; set; }
        public string ProblemDetails { get; set; }
        public string FilePath { get; set; }
        public string PreviousProblemFile { get; set; }
        public string PreviousProblemReportFile { get; set; }
        public string Status { get; set; }
        //public PatientsProblemPageForDoctorModel GetPatientsProblemPageForDoctorModel { get; set; }
        [ForeignKey("PatientProfileModel")]
        public int PatientId { get; set; }
        public PatientProfileModel PatientProfileModel { get; set; }
        [ForeignKey("DoctorProfileModel")]
        public int DoctorId { get; set; }
        public DoctorProfileModel DoctorProfileModel { get; set; }
    }
}
