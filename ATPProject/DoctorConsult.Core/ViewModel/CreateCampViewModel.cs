using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.ViewModel
{
    public class CreateCampViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campaign location cannot be empty")]
        public string CampaignLocation;

        [Required(ErrorMessage = "Campaign Duration cannot be empty")]
        public string CampaignDuration;

        [Required(ErrorMessage = "Campaign Date cannot be empty")]
        public DateTime CampaignDate;

        public double CampaignRent;
    }
}
