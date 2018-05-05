using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces.Base;
using System.Collections.Generic;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface IPrescriptionService : IBaseService<PrescriptionModel>
    {
        PrescriptionModel GetPrescribtionByPatientId(int patiendId);
        IEnumerable<PrescriptionModel> GetPresctions();
    }
}
