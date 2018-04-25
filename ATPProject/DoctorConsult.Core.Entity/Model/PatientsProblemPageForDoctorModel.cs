using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PatientsProblemPageForDoctorModel
    {
        [Required]
        public string ProblemSummary { get; set; }
        [Required]
        public string ProblemDetails { get; set; }
        public HttpPostedFileBase filePath { get; set; }
        public HttpPostedFileBase PreviousProblemReportFile { get; set; }
    }
}
