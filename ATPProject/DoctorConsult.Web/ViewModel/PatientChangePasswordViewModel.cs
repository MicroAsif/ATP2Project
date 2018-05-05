using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PatientChangePasswordViewModel
    {
        [Required]
        [RegularExpression(pattern: "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$")]
        public string OldPassword { get; set; }
        [Required]
        [RegularExpression(pattern: "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$")]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
