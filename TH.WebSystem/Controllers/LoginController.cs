using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Container;
using TH.Interfaces;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public bool AttemptLogin(LoginModel loginModel)
        {
            var username = loginModel.Username;
            var password = loginModel.Password;

            var staffMemberBusinessLogic = ThemeHospitalContainer.GetInstance<IStaffMemberBusinessLogic>();
            var staffMember = staffMemberBusinessLogic.LoginStaffMember(loginModel.Username, loginModel.Password);
            return staffMember != null ? true : false;
        }
    }
}