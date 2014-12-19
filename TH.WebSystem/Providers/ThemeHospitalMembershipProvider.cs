using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using TH.Domain.Enums;
using TH.Domain.User;
using TH.WebSystem.Services;

namespace TH.WebSystem.Providers
{
    public static class ThemeHospitalMembershipProvider
    {
        private static StaffMember User
        {
            get { return (StaffMember)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        private static SecurityService _securityService;
        public static SecurityService SecurityService
        {
            get { return _securityService ?? (_securityService = new SecurityService()); }
        }

        public static StaffMember GetCurrentUser()
        {
            return User;
        }

        public static LoginResult LoginCurrrentUser(string username, string password)
        {
            var result = SecurityService.LoginServiceBusinessLogic.LoginUser(username, password);

            if (result != null)
            {
                User = result;

                var userIdentity = new GenericIdentity(result.Username);
                HttpContext.Current.User = new GenericPrincipal(userIdentity, new[] { "Receptionist" });

                FormsAuthentication.SetAuthCookie(username, false);

                return LoginResult.Success;
            }

            return LoginResult.Invalid;
        }

        public static void LogoutCurrentUser()
        {
            var session = HttpContext.Current.Session;
            session.Clear();
            session.Abandon();

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public static bool IsLoggedIn()
        {
            return User != null;
        }
    }
}
