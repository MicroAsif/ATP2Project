using DoctorConsult.Core.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorConsult.Core.Service.Interfaces;

namespace DoctorConsult.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ISpecialityService _specialityService;
        private readonly IDoctorProfileService _doctorService;
        private readonly ICampaignService _campaignService;

        public HomeController(ILocationService locationService, ISpecialityService specialityService, IDoctorProfileService doctorService, ICampaignService campaignService)
        {
            _locationService = locationService;
            _specialityService = specialityService;
            _doctorService = doctorService;
            _campaignService = campaignService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.location = _locationService.LocationForDropdown();
            ViewBag.speciality = _specialityService.SpecialityForDropdown();
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(SearchViewModel searchViewModel)
        //{
        //    if (searchViewModel.CityName != null && searchViewModel.SpecialityName != null)
        //    {
        //        var doctors = _doctorService.SearchDoctors(searchViewModel.CityName, searchViewModel.SpecialityName);
        //        return RedirectToAction("DoctorList", doctors);
        //    }
        //    else
        //    {
        //         ViewBag.location = _locationService.LocationForDropdown();
        //    ViewBag.speciality = _specialityService.SpecialityForDropdown();
        //        return View("Index");
        //    }
        //}

        [HttpPost]
        public ActionResult DoctorList(SearchViewModel searchViewModel)
        {
            if (searchViewModel.CityName != null && searchViewModel.SpecialityName != null)
            {
                var doctors = _doctorService.SearchDoctors(searchViewModel.CityName, searchViewModel.SpecialityName);
                return View("DoctorList", doctors);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DoctorProfile(int doctorId)
        {
            var doctor = _doctorService.Find(doctorId);
            return View(doctor);
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

        [HttpGet]
        public ActionResult Campaign()
        {

            return View(model: _campaignService.All());
        }


        [HttpGet]
        public ActionResult CampaignDetails()
        {
            return View();
        }
    }
}