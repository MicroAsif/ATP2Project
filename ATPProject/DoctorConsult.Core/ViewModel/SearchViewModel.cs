using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.ViewModel
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please select a city")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please select an entity")]
        public string LookingFor { get; set; }

        [Required(ErrorMessage = "Please type an catagory")]
        public string SearchCatagory { get; set; }
    }
}
