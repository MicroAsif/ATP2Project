using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DoctorConsult.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IPatientProfileService _patientProfileService;
        private readonly IPrescriptionService _prescriptionService;

        public DoctorController(IPatientProfileService patientProfileService, IPrescriptionService prescriptionService)
        {
            _patientProfileService = patientProfileService;
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.NumberOfPatients = _patientProfileService.All().Count();
            ViewBag.NumberOfPrescribtions = _prescriptionService.All().Count();
            return View();
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

        public ActionResult ConsultRequestList()
        {
            return View("ConsultRequest");
        }

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
            return View(model: _prescriptionService.GetPrescribtionByPatientId(patientId));
        }

        [HttpGet]
        public ActionResult PatientsProblemPageForDoctor()
        {
            return View();
        }
    }
}