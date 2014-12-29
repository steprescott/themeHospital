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
            var patientHasOpenVisit = HospitalService.PatientBusinessLogic.IsOpenVisitForPatient(id);

            return View(new PatientDetailsModel
            {
                Patient = patient,
                HasOpenVisit = patientHasOpenVisit
            });
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

        [HttpGet]
        public ActionResult SearchPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchPatient(string patient)
        {
            var matchedPateints = HospitalService.PatientBusinessLogic.SearchPatient(patient);
            return PartialView("_PatientList", matchedPateints);
        }

        [HttpGet]
        public ActionResult Admit(Guid id)
        {
            var teams = HospitalService.TeamBusinessLogic.GetAll();
            var visit = HospitalService.PatientBusinessLogic.GetCurrentVisitForPatientId(id);
            
            return View(new AdmissionModel
            {
                PatientId = id,
                Teams = teams
            });
        }

        [HttpPost]
        public ActionResult Admit(AdmissionModel admissionModel)
        {
            HospitalService.PatientBusinessLogic.AdmitPatient(admissionModel.PatientId, admissionModel.TeamId);

            return RedirectToAction("Details", new { id = admissionModel.PatientId });
        }
    }
}