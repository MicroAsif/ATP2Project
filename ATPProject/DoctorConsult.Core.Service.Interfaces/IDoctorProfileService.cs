using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface IDoctorProfileService : IBaseService<DoctorProfileModel>
    {
        IEnumerable<DoctorProfileModel> SearchDoctors(string location, string speciality);
    }
}
