using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Model
{
    public class MedicalTestModel
    {
        [Required]
        public string TestName { get; set; }
    }
}
