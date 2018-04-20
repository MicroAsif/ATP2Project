using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorConsult.Core.Service.Interfaces;

namespace DoctorConsult.Web.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _service;
        // GET: Medicine
        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.All());
        }
    }
}