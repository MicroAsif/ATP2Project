using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicineForPrescription : BaseModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public string DailyTimes { get; set; }

        public int MedicineId { get; set; }
    }
}