using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    public class PrescriptionModel: BaseModel
    {

        

        [Required]
        public DateTime PrescribtionDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        
        
        [DisplayName("Patient")]
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public PatientProfileModel Patient { get; set; }
        public  ICollection<MedicineForPrescription> Medicines { get; set; }
        public  ICollection<MedicalTestModel> MedicalTests { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Cause { get; set; }
        public string ReferDoctor { get; set; }
        public string ReferDiagonstics { get; set; }

        public PrescriptionModel()
        {
            Medicines = new List<MedicineForPrescription>();
            MedicalTests = new List<MedicalTestModel>();
        }


    }
}
