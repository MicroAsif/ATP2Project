using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly ISpecialityService _specialityService;
        private readonly IDoctorProfileService _doctorProfileService;

        public PatientController(ISpecialityService specialityService, IDoctorProfileService doctorProfileService)
        {
            _specialityService = specialityService;
            _doctorProfileService = doctorProfileService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.speciality = _specialityService.SpecialityForDropdown();
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(SearchViewModel searchViewModel)
        {
            if (searchViewModel.CityName != null && searchViewModel.SpecialityName != null)
            {
                var doctors = _doctorProfileService.SearchDoctors(searchViewModel.CityName, searchViewModel.SpecialityName);
                return View("SearchResult", model: doctors);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public new ActionResult Profile()
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
        public ActionResult SearchResult(List<DoctorProfileModel> doctors)
        {
            return View(model: doctors);
        }

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

        [HttpGet]
        public ActionResult DoctorListByPatient(List<DoctorProfileModel> doctors)
        {
            doctors = new List<DoctorProfileModel>()
            {
                new DoctorProfileModel(){ FullName = "Annable", Email="annable@aiub.edu", Image = "", Specialist="Pain management", NewFee = 800, OldFee = 500 },
                new DoctorProfileModel(){ FullName = "Selena", Email="selena@aiub.edu", Image = "", Specialist="Medicine", NewFee = 100, OldFee = 600 }

            };

            return View(model: doctors);
        }

        [HttpGet]
        public ActionResult DoctorProfile(string id)
        {
            return View(model: new DoctorProfileModel() { FullName = "Annable", Email = "annable@aiub.edu", Image = "", Specialist = "Pain management", NewFee = 800, OldFee = 500 });
        }
    }
}