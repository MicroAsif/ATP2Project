using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    public class AdminSpecialistCityModel: BaseModel
    {        
        public string Specialist { get; set; }
        public string CityName { get; set; }
    }
}
