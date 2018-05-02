using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class AdminProfileModel : BaseModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string BloogGroup { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Phone { get; set; }
      
    }
}
