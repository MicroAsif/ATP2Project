using DoctorConsult.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DoctorList", searchViewModel);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult DoctorList(List<DoctorViewModel> doctors)
        {
            // Demo value
            doctors = new List<DoctorViewModel>()
            {
                new DoctorViewModel(){ Id = 1, FirstName="Annabelle", LastName="Ava", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Babeli", LastName="At.", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 1, FirstName="Ashley", LastName="Ash", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Mike", LastName="Kude.", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 1, FirstName="John", LastName="Abraham", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Angella", LastName="Angel", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 1, FirstName="Suvash", LastName="Chandra", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Alice", LastName="Allan", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 1, FirstName="Amy", LastName="Anderson", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Carmel", LastName="Cass", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" }
            };

            return View(model: doctors);
        }

        [HttpGet]
        public ActionResult DoctorProfile(DoctorProfileViewModel doctorProfileViewModel)
        {
            doctorProfileViewModel = new DoctorProfileViewModel()
            {
                Id = 1,
                FullName = "Daniel Dany",
                Email = "daniel@doctorconsult.com",
                BloogGroup = "A+",
                Gender = "Male",
                Specialist = "Pain management",
                Location = "Kuril, Kuratoli",
                Phone = "01750680929",
                Image = "http://nabeel.co.in/files/bootsnipp/team/4.jpg",
                Age = 24,
                NewFee = 1000,
                OldFee = 700,
                Address = "Pocket gate"
            };
            return View(model: doctorProfileViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Campaign()
        {
            List<CreateCampViewModel> createCampViewModel = new List<CreateCampViewModel>()
            {
                new CreateCampViewModel(){CampaignDuration="3 days", CampaignDate=Convert.ToDateTime("04-04-2018"), CampaignLocation="Banani model town", CampaignRent=50000 },

                new CreateCampViewModel(){CampaignDuration="4 days", CampaignDate=Convert.ToDateTime("01-01-2018"), CampaignLocation="Uttara", CampaignRent=900000 }
            };

            return View(createCampViewModel);
        }


        [HttpGet]
        public ActionResult CampaignDetails()
        {
            return View();
        }
    }
}