using DoctorConsult.Core.Entity.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PatientsConsultModel: BaseModel
    {
        [Required]
        public string ProblemSummary { get; set; }
        public string ProblemDetails { get; set; }
        public HttpPostedFileBase FilePath { get; set; }
        public HttpPostedFileBase PreviousProblemFile { get; set; }
        public HttpPostedFileBase PreviousProblemReportFile { get; set; }
    }
}
