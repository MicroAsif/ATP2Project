using DoctorConsult.Core.ViewModel;
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

        public ActionResult PatientList()
        {
            return View();
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

    }
}