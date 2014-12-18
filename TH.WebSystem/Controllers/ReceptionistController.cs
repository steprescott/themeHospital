using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class ReceptionistController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            return View(new AddPatientViewModel());
        }

        [HttpPost]
        public ActionResult AddPatient(AddPatientViewModel patient)
        {
            return RedirectToAction("Index", "Receptionist");
        }
    }
}