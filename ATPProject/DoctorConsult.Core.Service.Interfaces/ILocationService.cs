using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces.Base;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface ILocationService: IBaseService<LocationModel>
    {
        IEnumerable<SelectListItem> LocationForDropdown();
    }
}
