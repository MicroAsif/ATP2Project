using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    public class PatientProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Area { get; set; }
        [Required]
        public string District { get; set; }
        public string Division { get; set; }
        [Phone]
        [Display(Name = "Contact Number:")]
        public string ContactNumber { get; set; }
        public string Photo { get; set; }
    }
}
