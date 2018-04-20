using DoctorConsult.Core.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        public  ActionResult Profile()
        {
            return View(new DoctorProfileViewModel());
        }

        public ActionResult PatientList(List<PatientProfileViewModel> patients)
        {
            patients = new List<PatientProfileViewModel> {
            new PatientProfileViewModel() { Name="Samiur Rahman", age="21", BloodGroup="b+", Gender="Male" },
            new PatientProfileViewModel() { Name = "Asif Rahman", age = "21", BloodGroup = "b+", Gender = "Male" },
            new PatientProfileViewModel() { Name = "Jamy Ahmed", age = "21", BloodGroup = "b+", Gender = "Male" }
            };
            return View(model: patients);
        }
        public ActionResult ConsultRequestList()
        {
            return View("ConsultRequest");
        }

        public ActionResult Prescribe()
        {
            return View();
        }

        public ActionResult PrescribtionList()
        {
            return View();
        }

        public ActionResult PrescribtionDetails()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PatientsProblemPageForDoctor()
        {
            return View();
        }
        
    }
}