using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DoctorConsult.Core.ViewModel
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
        [Display(Name = "Insert File ")]
        public HttpPostedFileBase filePath { get; set; }

    }
}
