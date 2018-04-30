using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface ISpecialityService : IBaseService<SpecialityModel>
    {
        IEnumerable<SelectListItem> SpecialityForDropdown();
    }
}
