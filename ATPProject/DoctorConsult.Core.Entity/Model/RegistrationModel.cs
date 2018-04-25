using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    class RegistrationModel:BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(pattern: "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,50})$", ErrorMessage = "At least 6 characters with at least 1 number")]
        //[StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
