using DoctorConsult.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoctorList(List<DoctorProfileViewModel> doctors)
        {
            // Demo value
            doctors = new List<DoctorProfileViewModel>()
            {
                new DoctorProfileViewModel(){Id=1, FullName="John", Email="john@doctorconsult.com", Address="North town", Age=24, BloogGroup="B+", Gender="Male", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Pain Management" },

                new DoctorProfileViewModel(){Id=1, FullName="John", Email="john@doctorconsult.com", Address="North town", Age=24, BloogGroup="B+", Gender="Male", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Pain Management" }
            };

            return View(model: doctors);
        }

        [HttpGet]
        public ActionResult PatientList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCamp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCamp(List<CreateCampViewModel> createCampViewModel)
        {
            return View("Index", model: createCampViewModel);
        }

        [HttpGet]
        public ActionResult CampList(List<CreateCampViewModel> createCampViewModel)
        {
            createCampViewModel = new List<CreateCampViewModel>()
            {
                new CreateCampViewModel(){CampaignDuration="3 days", CampaignDate=Convert.ToDateTime("21-04-2018"), CampaignLocation="Banani model town", CampaignRent=50000 },

                new CreateCampViewModel(){CampaignDuration="4 days", CampaignDate=Convert.ToDateTime("21-05-2018"), CampaignLocation="Uttara", CampaignRent=900000 }
            };

            return View(model: createCampViewModel);
        }
    }
}