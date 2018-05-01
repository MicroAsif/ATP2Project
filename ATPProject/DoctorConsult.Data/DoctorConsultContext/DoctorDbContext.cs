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
        
    }
}
