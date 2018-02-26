using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorConsult.Core.ViewModel;

namespace DoctorConsult.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }




    }
}