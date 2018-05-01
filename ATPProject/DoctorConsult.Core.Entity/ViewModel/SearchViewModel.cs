using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please select a city")]
        public string CityName { get; set; }

        //[Required(ErrorMessage = "Please select an entity")]
        //public string LookingFor { get; set; }

        [Required(ErrorMessage = "Please select an catagory")]
        public string SearchCatagory { get; set; }

        public string DoctorNameInput { get; set; }

        public int CityId { get; set; }
        public int SpecialityId { get; set; }
    }
}