using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Infrustracture.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Service.Interfaces
{
    public class PrescriptionService : BaseService<PrescriptionModel>, IPrescriptionService
    {
        public IEnumerable<PrescriptionModel> GetPrescribtionByPatientId(int patientId)
        {
            return All().Include(x => x.Patient).Where(x => x.PatientId == patientId).ToList();
        }

        public IEnumerable<PrescriptionModel>  GetPresctions()
        {
            return All().Include(x => x.Patient).ToList();
        }
    }
}
