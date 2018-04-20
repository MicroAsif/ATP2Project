using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using DoctorConsult.Core.Entity.Model;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class PrescriptionViewModel
    {
        [Required]
        public int PrescribtionNo { get; set; }
        [Required]
        public DateTime PrescribtionDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string Cause { get; set; }
        [Required]
        public int PatientId { get; set; }
        public ICollection<MedicineModel> Medicines { get; set; }
        public ICollection<MedicalTestModel> MedicalTests { get; set; }

        public string Advice { get; set; }
        public PrescriptionViewModel()
        {
            Medicines = new Collection<MedicineModel>();
            MedicalTests = new Collection<MedicalTestModel>();
        }

    }
}
