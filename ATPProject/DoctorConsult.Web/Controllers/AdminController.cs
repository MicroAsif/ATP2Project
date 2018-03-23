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
                new DoctorProfileViewModel(){Id=1, FullName="Inna", Email="Inna@doctorconsult.com", Address="North town", Age=24, BloogGroup="AB+", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Pain Management" },

                new DoctorProfileViewModel(){Id=1, FullName="Jennifer Lawrence", Email="jennider@doctorconsult.com", Address="North town", Age=20, BloogGroup="O-", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Cardiology" },

                new DoctorProfileViewModel(){Id=1, FullName="Selina Gomez", Email="selina@doctorconsult.com", Address="North town", Age=24, BloogGroup="O+", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Pain Management" },

                new DoctorProfileViewModel(){Id=1, FullName="Daddy Yankee", Email="daddy@doctorconsult.com", Address="North town", Age=20, BloogGroup="B+", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Cardiology" },

                new DoctorProfileViewModel(){Id=1, FullName="Ricky Martin", Email="ricky@doctorconsult.com", Address="North town", Age=24, BloogGroup="AB+", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Pain Management" },

                new DoctorProfileViewModel(){Id=1, FullName="Shakira", Email="shakira@doctorconsult.com", Address="North town", Age=20, BloogGroup="O-", Gender="Female", Image="http://www.facebook.com", Location="Kuril Kuratoli", NewFee=800, OldFee=500, Phone="01521434331", Specialist="Cardiology" }
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
        public ActionResult CampList()
        {
            var createCampViewModel = new List<CreateCampViewModel>()
            {
                new CreateCampViewModel(){CampaignDuration="3 days", CampaignDate=Convert.ToDateTime("21-04-2018"), CampaignLocation="Banani model town", CampaignRent=50000 },

                new CreateCampViewModel(){CampaignDuration="4 days", CampaignDate=Convert.ToDateTime("21-05-2018"), CampaignLocation="Uttara", CampaignRent=900000 }
            };

            return View(model: createCampViewModel);
        }

        [HttpPost]
        [ActionName("CapmList")]
        public ActionResult DoCampList()
        {
            return View("CampList");
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            return View(model: new AdminProfileViewModel());
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            return View(model: changePasswordViewModel);
        }

        [HttpGet]
        public ActionResult DoctorProfile(DoctorProfileViewModel doctorProfileViewModel)
        {
            doctorProfileViewModel = new DoctorProfileViewModel()
            {
                Id = 1,
                FullName = "Ricky Martin",
                Email = "ricky@doctorconsult.com",
                Address = "North town",
                Age = 24,
                BloogGroup = "AB+",
                Gender = "Male",
                Image = "http://www.facebook.com",
                Location = "Kuril Kuratoli",
                NewFee = 800,
                OldFee = 500,
                Phone = "01521434331",
                Specialist = "Cardiology"
            };

            return View(model: doctorProfileViewModel);
        }

        [HttpPost]
        [ActionName("DoctorProfile")]
        public ActionResult DoDoctorProfile(DoctorProfileViewModel doctorProfileViewModel)
        {
            return View("DoctorProfile");
        }

        [HttpGet]
        public ActionResult DetailsCamp()
        {
            return View();
        }
    }
}