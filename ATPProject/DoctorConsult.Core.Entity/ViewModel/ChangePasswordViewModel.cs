using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(4)]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
