using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.WebSystem.Classes;
using TH.WebSystem.Classes.ActionFilters;
using TH.WebSystem.Services;

namespace TH.WebSystem.Controllers
{
    //NOTE(JB): Temporarily turned off so can navigate around but will need to put back in shortly
    //[ThemeHospitalAuthorisation]
    public class AuthorisedBaseController : Controller
    {
        private HospitalService _hospitalService;
        public HospitalService HospitalService
        {
            get { return _hospitalService ?? (_hospitalService = new HospitalService()); }
        }
    }
}