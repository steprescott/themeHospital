using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TH.WebSystem.Providers;

namespace TH.WebSystem.Classes.ActionFilters
{
    public class ThemeHospitalAuthorisationAttribute : AuthorizeAttribute 
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = ThemeHospitalMembershipProvider.GetCurrentUser();

            if (user != null)
            {
                var userIdentity = new GenericIdentity(user.Username);
                HttpContext.Current.User = new GenericPrincipal(userIdentity, new[] { user.StaffType.ToString() });
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Index"
                    })
            );
        }
    }
}