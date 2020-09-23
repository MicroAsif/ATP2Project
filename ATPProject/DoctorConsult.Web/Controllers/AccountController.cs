using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Entity.ViewModel;
using DoctorConsult.Core.Service.Interfaces;
using DoctorConsult.Infrustracture.Service;
using DoctorConsult.Web.CustomAuthentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoctorConsult.Web.Enums;
using DoctorConsult.Core.Entity.Model.AuthenticationModels;
using DoctorConsult.Infrustracture.Service.Helper;
using System.Transactions;

namespace DoctorConsult.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPatientProfileService _patientProfileService;
        private readonly IDoctorProfileService _doctorProfileService;
        private Helper _helper;

        public AccountController(IPatientProfileService patientProfileService, IDoctorProfileService doctorProfileService)
        {
            _patientProfileService = patientProfileService;
            _doctorProfileService = doctorProfileService;
            _helper = new Helper();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UserName, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
                    CustomSerializeModel userModel = new CustomSerializeModel();
                    if (user != null)
                    {
                        userModel.UserId = user.UserId;
                        userModel.FirstName = user.FirstName;
                        userModel.LastName = user.LastName;
                        userModel.RoleName = user.Roles.Select(r => r.RoleName).ToList();

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        if (userModel.RoleName.Contains(Enums.Roles.Patient.ToString()))
                        {
                            return RedirectToAction("Index", "Patient");
                        }
                        else if (userModel.RoleName.Contains(Enums.Roles.Doctor.ToString()))
                        {
                            return RedirectToAction("Index", "Doctor");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Account");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
            return View(loginView);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification  
                string userName = Membership.GetUserNameByEmail(model.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    return View(model);
                }

                //Save User Data   
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        var user = new User()
                        {
                            Username = model.Name,
                            Email = model.Email,
                            Password = model.Password,
                            ActivationCode = Guid.NewGuid(),
                            IsActive = true
                        };
                        int UserId = _helper.CreateUser(user);
                        int RoleId = _helper.GetRoleIdByRoleName(model.Type);
                        _helper.CreateRole(UserId, RoleId);
                        if (model.Type == "Doctor")
                        {
                            DoctorProfileModel doctor = new DoctorProfileModel();
                            doctor.FullName = model.Name;
                            doctor.Email = model.Email;
                            doctor.Password = model.Password;
                            //doctor.Gender = "Female";
                            //doctor.Specialist = "Dentist";
                            //doctor.Location = "Rajshahi";
                            //doctor.Phone = "017XXXXXXXX";
                            //doctor.NewFee = 1000;
                            //doctor.OldFee = 750;
                            _doctorProfileService.Insert(doctor);                          
                            scope.Complete();
                            return RedirectToAction("Login", "Account");
                        }
                        else if (model.Type == "Patient")
                        {
                            PatientProfileModel patient = new PatientProfileModel();
                            patient.Name = model.Name;
                            patient.Email = model.Email;
                            patient.Password = model.Password;
                            //patient.Gender = "Female";
                            //patient.BloodGroup = "B+";
                            //patient.District = "Dhaka";
                            _patientProfileService.Insert(patient);
                            scope.Complete();
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error    
                        scope.Dispose();
                        throw ex;
                    }


                }


                ////Verification Email  
                //messageRegistration = "Your account has been created successfully. ^_^";
                //statusRegistration = true;
            }
            else
            {
                messageRegistration = "Something Wrong!";
                return View(model);
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;
        }

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

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}