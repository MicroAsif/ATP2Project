using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorConsult.Core.Entity.Model;

namespace DoctorConsult.Data.DoctorConsultContext
{
    public class DoctorDbContext : DbContext
    {
        public DoctorDbContext() : base("DoctorConsultContext")
        {
            
        }

        public DbSet<MedicineModel> Medicines { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<SpecialityModel> Speciality { get; set; }
        public DbSet<AdminProfileModel> Admins { get; set; }
        public DbSet<CampaignModel> Campaigns { get; set; }
        public DbSet<DoctorProfileModel> Doctors { get; set; }
        public DbSet<MedicalTestModel> MedicalTests { get; set; }
        public DbSet<MedicineForPrescription> MedicineForPrescriptions { get; set; }
        public DbSet<PatientProfileModel> Patients { get; set; }
        public DbSet<PatientsConsultModel> Consults { get; set; }
        public DbSet<PatientsProblemPageForDoctorModel> PatientsConsults { get; set; }
        public DbSet<PrescriptionModel> Prescriptions { get; set; }


    }
}
