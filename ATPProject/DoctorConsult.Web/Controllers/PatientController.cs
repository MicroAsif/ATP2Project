using DoctorConsult.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class PatientController : Controller
    {
        // patient dashboard
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SearchResult", "Patient");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProfile(PatientProfileViewModel model)
        {
            return View(model: model);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }



        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(PatientChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Profile", "Patient");
            }
            else
            {
                return View(model: model);
            }
        }

        //Consult
        [HttpGet]
        public ActionResult PatientsConsult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientsConsult(PatientsConsult model)
        {
            return View(model: model);
        }

        public ActionResult ConsultList()
        {
            return View("ConsultList");
        }

        [HttpGet]
        public ActionResult SearchResult(List<DoctorViewModel> doctors)
        {
            doctors = new List<DoctorViewModel>()
            {
                new DoctorViewModel(){ Id = 1, FirstName="Annabelle", LastName="Ava", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Babeli", LastName="At.", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 1, FirstName="Ashley", LastName="Ash", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Mike", LastName="Kude.", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

               
            };

            return View(model: doctors);
        }


        //Invoice
        [HttpGet]
        public ActionResult Invoice()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PatientsList(List<PatientProfileViewModel> patients)
        {
            patients = new List<PatientProfileViewModel>() {
            new PatientProfileViewModel() { Name="Samiur Rahman", age="21", BloodGroup="b+", Gender="Male" },
            new PatientProfileViewModel() { Name = "Asif Rahman", age = "21", BloodGroup = "b+", Gender = "Male" },
            new PatientProfileViewModel() { Name = "Jamy Ahmed", age = "21", BloodGroup = "b+", Gender = "Male" }
            };

            return View("PatientsList", model: patients);
        }

        [HttpGet]
        public ActionResult PatientProfile(PatientProfileViewModel patientProfileViewModel)
        {
            patientProfileViewModel = new PatientProfileViewModel()
            {
                Name = "Sami",
                Email = "sami@aiub.edu",
                Birthday = "01-01-1994",
                age = "24",
                ContactNumber = "01521434331",
                BloodGroup = "A-ve",
                Area = "Dhaka",
                District = "Dhaka",
                Division = "Dhaka",
                Gender = "Male",
                Photo = "no url provied"
            };

            return View("PatientProfile", model: patientProfileViewModel);
        }
    }
}