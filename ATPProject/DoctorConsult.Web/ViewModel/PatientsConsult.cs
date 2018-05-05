using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PatientsConsult
    {
        [Required]
        [Display(Name ="Problem Summary: ")]
        [StringLength(200,ErrorMessage ="Maximum 200 words")]
        public string ProblemSummary { get; set; }
        [Required]
        [Display(Name = "Problem Details: ")]
        public string ProblemDetails { get; set; }
        [Display(Name = "Please Upload Reports(If Required) ")]
        public HttpPostedFileBase filePath { get; set; }
        [Display(Name = "Please Upload Previous Doctor's Prescription If Consulted Before (If Possible) ")]
        public HttpPostedFileBase PreviousProblemFile { get; set; }
        [Display(Name = "Please Upload Previous Reports (Optional) ")]
        public HttpPostedFileBase PreviousProblemReportFile { get; set; }
    }
}
