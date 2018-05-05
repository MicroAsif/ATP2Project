using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class AdminSpecialistCityViewModel
    {
        [Required(ErrorMessage = "Specialist field cannot be empty")]
        public string Specialist { get; set; }

        [Required(ErrorMessage = "Please type a valid city name")]
        public string CityName { get; set; }
    }
}
