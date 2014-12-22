using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Enums;
using TH.WebSystem.Models;
using TH.WebSystem.Providers;

namespace TH.WebSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public bool AttemptLogin(LoginModel loginModel)
        {
            var result = ThemeHospitalMembershipProvider.LoginCurrrentUser(loginModel.Username, loginModel.Password);
            
            if (result == LoginResult.Success)
            {
                if (System.Web.HttpContext.Current.User.IsInRole(StaffType.Receptionist.ToString()))
                {
                    RedirectToAction("Index", "Receptionist");
                }
                else if (System.Web.HttpContext.Current.User.IsInRole(StaffType.Consultant.ToString()))
                {
                    RedirectToAction("Index", "Consultant");
                }
                else if (System.Web.HttpContext.Current.User.IsInRole(StaffType.Doctor.ToString()))
                {
                    RedirectToAction("Index", "JuniorDoctor");
                }
            }
            return false;
        }
    }
}