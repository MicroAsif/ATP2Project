using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DoctorConsult.Web.ViewModel;

namespace DoctorConsult.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IPatientProfileService _patientProfileService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMedicineForPrescriptionService _medicineForPrescriptionService;
        private readonly IMedicalTestService _medicalTestService;
        private readonly IPatientsConsultService _patientsConsultService;
        private readonly IPatientConsultSingleService _patientConsultSingleService;

        public DoctorController(IPatientProfileService patientProfileService, IPrescriptionService prescriptionService, 
            IMedicineForPrescriptionService medicineForPrescriptionService, IMedicalTestService medicalTestService, IPatientsConsultService patientsConsultService, IPatientConsultSingleService patientConsultSingleService)
        {
            _patientProfileService = patientProfileService;
            _prescriptionService = prescriptionService;
            _medicineForPrescriptionService = medicineForPrescriptionService;
            _medicalTestService = medicalTestService;
            _patientsConsultService = patientsConsultService;
            _patientConsultSingleService = patientConsultSingleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vm = new DoctorDashboardViewModel
            {
               AcceptedPatients =  _patientProfileService.All().Count(), 
               Prescription = _prescriptionService.All().Count()
            };
            return View(vm);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            return View(new DoctorProfileViewModel());
        }

        [HttpGet]
        public ActionResult PatientList()
        {
            return View(model: _patientProfileService.All());
        }

        [HttpGet]
        public ActionResult ConsultRequestList()
        {
            return View("ConsultRequest", _patientsConsultService.All().Include(x => x.DoctorProfileModel).Include(p => p.PatientProfileModel).ToList());
        }

        [HttpGet]
        public ActionResult Prescribe()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PrescribtionList()
        {
            var prescriptions = _prescriptionService.GetPresctions();
            return View(prescriptions);
        }

        [HttpGet]
        public ActionResult PrescribtionDetails(int patientId)
        {
           var prescriptions = _prescriptionService.GetPrescribtionByPatientId(patientId);
            prescriptions.Medicines = _medicineForPrescriptionService.All().Include(x=>x.MedicineModel)
                                                                     .Where(x => x.PrescriptionId == prescriptions.Id).ToList();

            prescriptions.MedicalTests = _medicalTestService.All()
                                                            .Where(x => x.PrescriptionId == prescriptions.Id).ToList();


            return View(prescriptions);

        }

        [HttpGet]
        public ActionResult PatientsProblemPageForDoctor(int patientId)
        {
            ViewBag.patientId = patientId;
            return View(_patientConsultSingleService.FindLast(patientId));
        }

        [HttpPost]
        [ActionName("PatientsProblemPageForDoctor")]
        public ActionResult TakeToThePrescribePage(int? patientId)
        {
            if (patientId != 0)
            {
                ViewBag.patientId = patientId;
                return RedirectToAction("Prescribe", "Doctor");
            }
            return View();
        }
    }
}