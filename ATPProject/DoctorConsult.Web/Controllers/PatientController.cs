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
        private readonly IPatientProfileService _patientProfileService;
        private readonly IDoctorProfileService _doctorProfileService;

        public PatientController(ISpecialityService specialityService, IPatientProfileService patientProfileService, IDoctorProfileService doctorProfileService)
        {
            _specialityService = specialityService;
            _patientProfileService = patientProfileService;
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
        public new ActionResult Profile(PatientProfileModel model)
        {
            return View(model: _patientProfileService.Find(1));
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
        public ActionResult PatientsList(List<PatientProfileModel> patients)
        {
            return View("PatientsList", model: _patientProfileService.All());
        }

        [HttpGet]
        public ActionResult PatientProfile(int patientId)
        {
            return View("PatientProfile", model: _patientProfileService.Find(patientId));
        }

        [HttpGet]
        public ActionResult DoctorListByPatient()
        {
            return View(model: _doctorProfileService.All());
        }

        [HttpGet]
        public ActionResult DoctorProfile(int doctorId)
        {
            return View(model: _doctorProfileService.Find(doctorId));
        }
    }
}