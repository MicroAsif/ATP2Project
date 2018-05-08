using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class MedicalTestModel : BaseModel
    {
        public MedicalTestModel()
        {
            
        }
        [Required]
        public string TestName { get; set; }


        [ForeignKey("PrescriptionModel")]
        public int PrescriptionId { get; set; }
        public PrescriptionModel PrescriptionModel { get; set; }

    }
}