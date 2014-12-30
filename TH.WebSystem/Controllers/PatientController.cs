using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.User;
using TH.WebSystem.Models;

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

        [HttpPost]
        public ActionResult SearchPatient(string patient)
        {
            var matchedPateints = HospitalService.PatientBusinessLogic.SearchPatient(patient);
            return PartialView("_PatientList", matchedPateints);
        }

        public ActionResult SearchPatient()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult DisplayWards()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards().OrderBy(ward => ward.Number).ToList();
            return View(new DisplayWardsViewModel { Wards = wards});
        }
    }
}