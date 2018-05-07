using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces;
using DoctorConsult.Core.Service.Interfaces.Base;
using DoctorConsult.Infrustracture.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Infrustracture.Service
{
    public class PatientConsultSingleService : BaseService<PatientsConsultModel>, IPatientConsultSingleService
    {
        public PatientsConsultModel FindLast(int patientId)
        {
            return All().FirstOrDefault(pc => pc.Id == patientId);
        }
    }
}
