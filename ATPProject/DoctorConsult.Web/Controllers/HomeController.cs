using DoctorConsult.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DoctorList", searchViewModel);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult DoctorList(List<DoctorViewModel> doctors)
        {
            // Demo value
            doctors = new List<DoctorViewModel>()
            {
                new DoctorViewModel(){ Catagory="abc", Location= "cdf", Name = "fgh", Specialist = "hij" },
                new DoctorViewModel(){ Catagory="mk", Location= "cdf", Name = "fgh", Specialist = "hij" },
                new DoctorViewModel(){ Catagory="er", Location= "cdf", Name = "fgh", Specialist = "hij" }
            };

            return View(model: doctors);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}