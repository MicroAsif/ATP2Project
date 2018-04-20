using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorConsult.Core.Entity.ViewModel
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
