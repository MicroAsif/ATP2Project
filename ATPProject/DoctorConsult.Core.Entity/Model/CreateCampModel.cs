using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    class CreateCampModel: BaseModel
    {

        [Required(ErrorMessage = "Campaign location cannot be empty")]
        public string CampaignLocation;

        [Required(ErrorMessage = "Campaign Duration cannot be empty")]
        public string CampaignDuration;

        [Required(ErrorMessage = "Campaign Date cannot be empty")]
        public DateTime CampaignDate;

        public double CampaignRent;
    }
}
