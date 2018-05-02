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
    public class DoctorService : BaseService<DoctorProfileModel>, IDoctorProfileService
    {
        public IEnumerable<DoctorProfileModel> SearchDoctors(string location, string speciality)
        {
            return  All().Where(x=>x.Location.ToLower() == location.ToLower() 
                                && x.Specialist.ToLower() == speciality.ToLower());
        }
    }
}
