using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces;
using DoctorConsult.Infrustracture.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Infrustracture.Service
{
    public class PatientService : BaseService<PatientProfileModel>, IPatientProfileService
    {
        public PatientProfileModel FindByAuth(string email, string password)
        {
            return All().SingleOrDefault(p => p.Email == email && p.Password == password);
        }
    }
}
