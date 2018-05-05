using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicalTestModel : BaseModel
    {
        [Required]
        public string TestName { get; set; }

        
        [DisplayName("Prescription")]
        public int? PrescriptionId { get; set; }
      
    }
}