using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace DoctorConsult.Web.ViewModel
{
    public class DoctorDashboardViewModel
    {
        public int Doctor { get; set; }
        public int Prescription { get; set; }
        public int AcceptedPatients { get; set; }
        public int AccpetedAppoiments { get; set; }
        public int TreatmentsOpen { get; set; }
        public int TreatmentsClose { get; set; }
    }
}