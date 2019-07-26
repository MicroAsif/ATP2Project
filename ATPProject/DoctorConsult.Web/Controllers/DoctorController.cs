using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DoctorConsult.Core.Entity.Model;
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
        private readonly IPatientsProblemPageForDoctorService _patientProblemService;
        private readonly IDoctorProfileService _doctorProfileService;

        public DoctorController(IPatientProfileService patientProfileService, IPrescriptionService prescriptionService,
            IMedicineForPrescriptionService medicineForPrescriptionService, IMedicalTestService medicalTestService,
            IPatientsConsultService patientsConsultService, IPatientConsultSingleService patientConsultSingleService,
            IPatientsProblemPageForDoctorService patientProblemService, IDoctorProfileService doctorProblemService)
        {
            _patientProfileService = patientProfileService;
            _prescriptionService = prescriptionService;
            _medicineForPrescriptionService = medicineForPrescriptionService;
            _medicalTestService = medicalTestService;
            _patientsConsultService = patientsConsultService;
            _patientConsultSingleService = patientConsultSingleService;
            _patientProblemService = patientProblemService;
            _doctorProfileService = doctorProblemService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vm = new DoctorDashboardViewModel
            {
                AcceptedPatients = _patientProfileService.All().Count(),
                Prescription = _prescriptionService.All().Count()
            };
            return View(vm);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            return View(model: _doctorProfileService.Find(1));
        }
        [HttpPost]
        [ActionName("Profile")]
        public new ActionResult ProfileEdit(DoctorProfileModel model)
        {

            if (model != null)
            {
                model = new DoctorProfileModel()
                {
                    Id = 1,
                    FullName = model.FullName,
                    Address = model.Address,
                    Age = model.Age,
                    BloodGroup = model.BloodGroup,
                    Email = model.Email,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    Specialist = model.Specialist,
                    Location = model.Location,
                    OldFee = model.OldFee,
                    NewFee = model.NewFee,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,

                    Password = model.Password


                };
                _doctorProfileService.Update(model);
                return RedirectToAction("Index", "Doctor");
            }
            return View();
        }


        [HttpGet]
        public ActionResult PatientList()
        {
            return View(model: _patientProfileService.All());
        }

        //[HttpPost]
        //public ActionResult PatientList()
        //{
        //    return View(model: _patientProfileService.All());
        //}

        [HttpGet]
        public ActionResult ConsultRequestList()
        {
            return View("ConsultRequest", _patientsConsultService.All().Include(x => x.DoctorProfileModel).Include(p => p.PatientProfileModel).ToList());
        }

        [HttpGet]
        public ActionResult Prescribe(int patientId)
        {
            var Prescription = new PrescriptionModel { PatientId = patientId };
            return View(Prescription);
        }

        [HttpPost]
        public ActionResult Prescribtion(PrescriptionModel model)
        {
            try
            {
                var prescription = new PrescriptionModel
                {
                    PatientId = model.PatientId,
                    Cause = model.Cause,
                    Comment = model.Comment,
                    ReferDiagonstics = model.ReferDiagonstics,
                    ReferDoctor = model.ReferDoctor,
                    PrescribtionDate = model.PrescribtionDate,
                    NextVisitDate = model.NextVisitDate
                };
                _prescriptionService.Insert(prescription);
                if (model.MedicalTests.Any())
                {
                    foreach (var test in model.MedicalTests)
                    {
                        _medicalTestService.Insert(new MedicalTestModel
                        {
                            TestName = test.TestName,
                            PrescriptionId = prescription.Id,
                            CreatedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow
                        });
                    }
                }
                if (model.Medicines.Any())
                {
                    foreach (var medicine in model.Medicines)
                    {
                        _medicineForPrescriptionService.Insert(new MedicineForPrescription
                        {
                            DailyTimes = medicine.DailyTimes,
                            Name = medicine.Name,
                            Quantity = medicine.Quantity,
                            Days = medicine.Days,
                            PrescriptionId = prescription.Id,
                            CreatedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow
                        });
                    }
                }
                return Json(new { error = false, message = "Data saved successfully" });
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

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
            prescriptions.Medicines = _medicineForPrescriptionService.All()
                                                                     .Where(x => x.PrescriptionId == prescriptions.Id).ToList();

            prescriptions.MedicalTests = _medicalTestService.All()
                                                            .Where(x => x.PrescriptionId == prescriptions.Id).ToList();


            return View(prescriptions);

        }

        [HttpGet]
        public ActionResult PatientsProblemPageForDoctor(int patientId)
        {
            ViewBag.patientId = patientId;
            return View(_patientProblemService.All().FirstOrDefault(x => x.PatintId == patientId));
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