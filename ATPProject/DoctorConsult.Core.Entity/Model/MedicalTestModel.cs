using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicalTestModel : BaseModel
    {
        [Required]
        public string TestName { get; set; }
    }
}