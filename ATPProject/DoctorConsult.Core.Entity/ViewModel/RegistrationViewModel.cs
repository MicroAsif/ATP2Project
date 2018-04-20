using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class RegistrationViewModel
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
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Type { get; set; }

    }
}
