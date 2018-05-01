using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class PrescriptionModel: BaseModel
    {
     
        [Required]
        public DateTime PrescribtionDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string Cause { get; set; }
        [Required]
        public int PatientId { get; set; }
        public ICollection<MedicineForPrescription> Medicines { get; set; }
        public ICollection<MedicalTestModel> MedicalTests { get; set; }
        public string Advice { get; set; }
        

    }
}
