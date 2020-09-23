using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    public class DoctorProfileModel: BaseModel
    {
 
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Password { get; set; }

        public string BloodGroup { get; set; }


        public string Gender { get; set; }


        public string Specialist { get; set; }


        public string Location { get; set; }


        public string Phone { get; set; }

        public string Image { get; set; }

        public int Age { get; set; }


        public double NewFee { get; set; }

        public double OldFee { get; set; }

        public string Address { get; set; }
    }
}
