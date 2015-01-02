using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.WebSystem.Models;
using TH.WebSystem.Services;

namespace TH.WebSystem.Controllers
{
    public class VisitController : AuthorisedBaseController
    {
        public ActionResult Details(Guid id)
        {
            var visit = HospitalService.VisitBusinessLogic.GetVisitWithId(id);
            return View(new VisitDetailsViewModel {
                Visit = visit
            });
        }
    }
}