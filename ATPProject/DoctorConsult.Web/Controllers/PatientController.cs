using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorConsult.Web.ViewModel;

namespace DoctorConsult.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly ISpecialityService _specialityService;
        private readonly IPatientProfileService _patientProfileService;
        private readonly IDoctorProfileService _doctorProfileService;
        private readonly IPatientsConsultService _consultService;
        private readonly IPatientsConsultService _patientsConsultService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMedicalTestService _testService;
        private readonly IMedicineForPrescriptionService _medicineForPrescriptionService;
        private readonly IPatientsProblemPageForDoctorService _patientsProblemPageForDoctorService;


        public PatientController(ISpecialityService specialityService, IPatientProfileService patientProfileService,
            IDoctorProfileService doctorProfileService, IPatientsConsultService consultService,
            IPatientsConsultService patientsConsultService, IPrescriptionService prescriptionService, IMedicalTestService testService,
            IMedicineForPrescriptionService medicineForPrescriptionService, IPatientsProblemPageForDoctorService patientsProblemPageForDoctorService)
        {
            _specialityService = specialityService;
            _patientProfileService = patientProfileService;
            _doctorProfileService = doctorProfileService;
            _consultService = consultService;
            _patientsConsultService = patientsConsultService;
            _prescriptionService = prescriptionService;
            _testService = testService;
            _medicineForPrescriptionService = medicineForPrescriptionService;
            _patientsProblemPageForDoctorService = patientsProblemPageForDoctorService;
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
        public ActionResult EditProfile(PatientProfileModel model)
        {
            //if (model != null)
            //{

            //    _patientProfileService.Update(model);
            //    return RedirectToAction("Profile", "Patient");
            //}
            if (model != null)
            {
                model = new PatientProfileModel()
                {
                    Id = 1,
                    Name = model.Name,
                    Password = model.Password,
                    Age = model.Age,
                    Email = model.Email,
                    Birthday = model.Birthday,
                    BloodGroup = model.BloodGroup,
                    Gender = model.Gender,
                    District = model.District,
                    Division = model.Division,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow

                };
                _patientProfileService.Update(model);
                return RedirectToAction("Profile", "Patient");
            }
            return View();
        }

        [HttpGet]
        [ActionName("EditProfile")]
        public ActionResult EditProfileView(PatientProfileModel model)
        {

            return View(model: _patientProfileService.Find(1));
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
        public ActionResult PatientsConsult(int? doctorId)
        {
            ViewBag.doctorId = doctorId ?? 0;
            ViewBag.PatintId = 4;
            return View();
        }

        [HttpPost]
        public ActionResult PatientsConsult(PatientsProblemPageForDoctorModel model)
        {
            if (model != null)
            {
                //model.PatintId = 1;
                //model.DoctorId = 3;
                model.Status = "pending";
                _patientsProblemPageForDoctorService.Insert(model);
                return RedirectToAction("PatientsConsult", "Patient");
            }
            return View(model: model);
        }

        [HttpGet]
        public ActionResult ConsultList()
        {
            var a = _patientsProblemPageForDoctorService.All()
                .Include(x => x.PatientProfile)
                .Include(x => x.DoctorProfileModel);

            return View(a);
        }

        [HttpGet]
        public ActionResult SearchResult(List<DoctorProfileModel> doctors)
        {
            return View(model: doctors);
        }

        [HttpGet]
        public ActionResult Invoice(int prescribtionId)
        {
            var prescribtion = _prescriptionService.All().Include(x => x.Patient).SingleOrDefault(x => x.Id == prescribtionId);
            if (prescribtion != null)
            {
                prescribtion.MedicalTests = _testService.All().Where(x => x.PrescriptionId == prescribtion.Id).ToList();
                prescribtion.Medicines =
                    _medicineForPrescriptionService.All().Where(x => x.PrescriptionId == prescribtion.Id).ToList();
            }
            var invoice = new InvoiceViewModel
            {
                Prescribtion = prescribtion,
                Doctor = _doctorProfileService.All().FirstOrDefault()
            };
            return View(invoice);
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