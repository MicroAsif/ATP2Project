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
                new DoctorViewModel(){ Id = 1, FirstName="John", LastName="Abraham", Email="john@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1994"), BloodGroup= "A+", Gender="Male", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" },

                new DoctorViewModel(){ Id = 2, FirstName="Babeli", LastName="At.", Email="babeli@aiub.edu", Password = "1234", Bithdate = Convert.ToDateTime("01-01-1989"), BloodGroup= "B+", Gender="Female", Specialist="Pain management", Location="Kuril, Kuratoli", ContactNumber="015XXXXXXXX", Image="no image" }
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

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}