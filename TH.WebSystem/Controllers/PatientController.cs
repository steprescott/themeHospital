using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.User;

namespace TH.WebSystem.Controllers
{
    public class PatientController : AuthorisedBaseController
    {
        // GET: Patient
        public ActionResult Index()
        {
            var patients = HospitalService.PatientBusinessLogic.GetAllPatients().ToList();

            patients = Enumerable.Range(0, 10).Select(p => new Patient
            {
                UserId = Guid.NewGuid(),
                Firstname = "Test",
                LastName = "name",
                ContactNumber = "2456456456",
            }).ToList();

            return View(patients);
        }

        public ActionResult Details(Guid id)
        {
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);

            return View(patient);
        }

        public ActionResult Edit(Guid id)
        {
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);

            return View(patient);
        }
    }
}