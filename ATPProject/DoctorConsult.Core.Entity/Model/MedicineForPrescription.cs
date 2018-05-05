using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicineForPrescription : BaseModel
    {
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public string DailyTimes { get; set; }

        [ForeignKey("MedicineModel")]
        [DisplayName("Medicine")]
        public int? MedicineId { get; set; }
        public MedicineModel MedicineModel { get; set; }



       
        [DisplayName("Prescription")]
        public int? PrescriptionId { get; set; }
        public PrescriptionModel PrescriptionModel { get; set; }
    }
}