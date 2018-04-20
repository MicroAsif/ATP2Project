using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicineModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Manufacture { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Days{ get; set; }
        [Required]
        public string DailyTimes { get; set; }
    }
}
