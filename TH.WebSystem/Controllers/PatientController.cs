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
        public ActionResult Index()
        {
            var patients = HospitalService.PatientBusinessLogic.GetAllPatients().ToList();

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

        public ActionResult Edit(Patient patient)
        {
            HospitalService.PatientBusinessLogic.InsertOrUpdatePatient(patient);

            return RedirectToAction("Details", new { id = patient.UserId });
        }
    }
}