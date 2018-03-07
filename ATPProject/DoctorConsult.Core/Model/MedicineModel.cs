using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Model
{
    public class MedicineModel
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
