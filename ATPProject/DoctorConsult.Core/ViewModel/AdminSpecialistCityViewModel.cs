using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.ViewModel
{
    public class AdminSpecialistCityViewModel
    {
        [Required(ErrorMessage = "Specialist field cannot be empty")]
        public string Specialist { get; set; }

        [Required(ErrorMessage = "Please type a valid city name")]
        public string CityName { get; set; }
    }
}
