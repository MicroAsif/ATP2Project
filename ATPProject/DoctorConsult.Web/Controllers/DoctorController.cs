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
        public ActionResult Index(DoctorViewModel doctor)
        {
            return View(model: new DoctorViewModel() { Id = 1, FirstName = "John", LastName = "Abraham", Email = "john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup = "A+", Gender = "Male", Specialist = "Pain management", Location = "Kuril, Kuratoli", ContactNumber = "015XXXXXXXX", Image = "no image" });
        }

        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult ChangePassword()
        {
            return View();
        }

        public  ActionResult Profile()
        {
            return View();
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