using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class AdminProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string BloogGroup { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Specialist { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        [Required]
        public double NewFee { get; set; }
        [Required]
        public double OldFee { get; set; }
        public string Address { get; set; }
    }
}
