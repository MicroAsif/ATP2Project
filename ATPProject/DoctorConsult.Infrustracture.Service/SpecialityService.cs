using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces;
using DoctorConsult.Infrustracture.Service.Base;

namespace DoctorConsult.Infrustracture.Service
{
    public class SpecialityService : BaseService<SpecialityModel>, ISpecialityService
    {
        public IEnumerable<SelectListItem> SpecialityForDropdown()
        {
            return All().ToList().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}
