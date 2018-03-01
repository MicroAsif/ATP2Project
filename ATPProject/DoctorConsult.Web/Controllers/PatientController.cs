using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class PatientController : Controller
    {
        // patient dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}