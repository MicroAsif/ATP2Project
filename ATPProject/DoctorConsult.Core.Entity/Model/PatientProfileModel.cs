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
        [Required]
        public string Name { get; set; }

        public string Age { get; set; }

        [Required]
        public string Email { get; set; }

    
        public string Password { get; set; }

        public string Birthday { get; set; }

  
        public string BloodGroup { get; set; }


        public string Gender { get; set; }

        public string Area { get; set; }


        public string District { get; set; }

        public string Division { get; set; }

        [Phone]
        [Display(Name = "Contact Number:")]
        public string ContactNumber { get; set; }

        public string Photo { get; set; }
    }
}
