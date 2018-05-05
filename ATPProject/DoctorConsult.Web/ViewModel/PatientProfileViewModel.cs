using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PatientProfileViewModel
    {
        public string Name { get; set; }
        public string age { get; set; }
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
