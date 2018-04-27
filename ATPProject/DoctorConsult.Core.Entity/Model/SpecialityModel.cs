using System.ComponentModel;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class SpecialityModel : BaseModel
    {
        [DisplayName("Speciality")]
        public string Name { get; set; }
    }
}
