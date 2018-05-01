using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    [Table("Speciality")]
    public class SpecialityModel : BaseModel
    {
        [DisplayName("Speciality")]
        public string Name { get; set; }
    }
}
