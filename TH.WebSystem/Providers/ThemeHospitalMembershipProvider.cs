using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using TH.Domain.Enums;
using TH.Domain.Other;
using TH.WebSystem.Services;

namespace TH.WebSystem.Providers
{
    public static class ThemeHospitalMembershipProvider
    {
        private static ApplicationUser User
        {
            get { return (ApplicationUser)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        private static SecurityService _securityService;
        public static SecurityService SecurityService
        {
            get { return _securityService ?? (_securityService = new SecurityService()); }
        }

        public static ApplicationUser GetCurrentUser()
        {
            return User;
        }

        public static StaffType GetUserRole()
        {
            var user = GetCurrentUser();
            return user.StaffType;
        }

        public static LoginResult LoginCurrrentUser(string username, string password)
        {
            var result = SecurityService.LoginServiceBusinessLogic.LoginStaffMember(username, password);

            if (result != null)
            {
                User = result;

                var userIdentity = new GenericIdentity(result.Username);
                HttpContext.Current.User = new GenericPrincipal(userIdentity, new[] { result.StaffType.ToString() });

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
