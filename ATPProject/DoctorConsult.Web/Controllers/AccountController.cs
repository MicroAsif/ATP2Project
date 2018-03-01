using DoctorConsult.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsult.Web.Controllers
{
    public class AccountController : Controller
    {
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index","Patient");
            }
            else
            {
                return View(model: model);
            }
        }

        //Registration
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
                return RedirectToAction("Login","Account");
            }
            else
            {
                return View(model: model);
            }
        }

        //Forget Password

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