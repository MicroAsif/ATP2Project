using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Entity.Model
{
    [Table("Location")]
    public class LocationModel : BaseModel
    {
        [DisplayName("Location")]
        public string Name { get; set; }
    }
}
