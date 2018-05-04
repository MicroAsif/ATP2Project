using DoctorConsult.Core.Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Entity.Model
{
    public class CampaignModel: BaseModel
    {
       

        [Required(ErrorMessage = "Campaign location cannot be empty")]
        public string CampaignLocation { set; get; }

        [Required(ErrorMessage = "Campaign Duration cannot be empty")]
        public string CampaignDuration { set; get; }


        [Required(ErrorMessage = "Campaign Date cannot be empty")]
        public DateTime CampaignDate { set; get; }

        public double CampaignRent { set; get; }
    }
}
