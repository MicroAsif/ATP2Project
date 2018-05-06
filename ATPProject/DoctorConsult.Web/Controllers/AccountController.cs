using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using DoctorConsult.Infrustracture.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPatientProfileService _patientProfileService;
        private readonly IDoctorProfileService _doctorProfileService;

        public AccountController(IPatientProfileService patientProfileService, IDoctorProfileService doctorProfileService)
        {
            _patientProfileService = patientProfileService;
            _doctorProfileService = doctorProfileService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && model.Email != null && model.Password != null)
            {
                if(_patientProfileService.FindByAuth(model.Email,model.Password)!=null)
                {
                    return RedirectToAction("Index", "Patient");
                }
                else if (_doctorProfileService.FindByAuth(model.Email, model.Password) != null)
                {
                    return RedirectToAction("Index", "Doctor");
                }else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return View(model: model);
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Type=="Doctor")
                {
                    DoctorProfileModel doctor = new DoctorProfileModel();
                    doctor.FullName = model.Name;
                    doctor.Email = model.Email;
                    doctor.Password = model.Password;
                    doctor.Gender = "Female";
                    doctor.Specialist = "Dentist";
                    doctor.Location = "Rajshahi";
                    doctor.Phone = "017XXXXXXXX";
                    doctor.NewFee = 1000;
                    doctor.OldFee = 750;
                    _doctorProfileService.Insert(doctor);
                    return RedirectToAction("Login", "Account");
                }else if(model.Type=="Patient")
                {
                    PatientProfileModel patient = new PatientProfileModel();
                    patient.Name = model.Name;
                    patient.Email = model.Email;
                    patient.Password = model.Password;
                    patient.Gender = "Female";
                    patient.BloodGroup = "B+";
                    patient.District = "Dhaka";
                    _patientProfileService.Insert(patient);
                    
                    return RedirectToAction("Login", "Account");
                }
                return RedirectToAction("Login","Account");
            }
            else
            {
                return View(model: model);
            }
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ResetPassword", "Account");
            }
            else
            {
                return View(model: model);
            }
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(model: model);
            }
        }
    }
}