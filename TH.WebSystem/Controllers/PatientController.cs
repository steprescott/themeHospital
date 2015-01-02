using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TH.Domain.Enums;
using TH.Domain.Other;
using TH.Domain.User;
using TH.WebSystem.Models;
using TH.WebSystem.Providers;

namespace TH.WebSystem.Controllers
{
    public class PatientController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            var userId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            if (ThemeHospitalMembershipProvider.GetUserRole() == StaffType.Consultant)
            {
                return View(HospitalService.VisitBusinessLogic.GetOpenVisitsForConsultantId(userId));
            }
            if (ThemeHospitalMembershipProvider.GetUserRole() == StaffType.Doctor)
            {
                return View(HospitalService.VisitBusinessLogic.GetOpenVisitsForDoctorId(userId));
            }

            return View(HospitalService.VisitBusinessLogic.GetAllPatientsWithOpenVisits());
        }

        public ActionResult Details(Guid id)
        {
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);

            return View(new PatientDetailsModel
            {
                Patient = patient,
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
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string patient)
        {
            var matchedPateints = HospitalService.PatientBusinessLogic.SearchPatient(patient);
            return PartialView("_PatientList", matchedPateints);
        }

        [HttpGet]
        public ActionResult Admit(Guid id)
        {
            var teams = HospitalService.TeamBusinessLogic.GetAll();
            
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

        [HttpGet]
        public ActionResult Dismiss(Guid id)
        {
            return View(new DismissModel
            {
                PatientId = id,
                Patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id)
            });
        }

        [HttpPost]
        public ActionResult Dismiss(DismissModel dismissModel)
        {
            HospitalService.PatientBusinessLogic.DismissPatient(dismissModel.PatientId);
            return RedirectToAction("Details", new { id = dismissModel.PatientId });
        }

        public ActionResult Options(Guid id)
        {
            var currentVisit = HospitalService.PatientBusinessLogic.GetCurrentVisitForPatientId(id);

            return View(new PatientOptionsViewModel
            {
                PatientId = id,
                VisitId = currentVisit != null ? currentVisit.VisitId : Guid.Empty
            });
        }

        public ActionResult DisplayWards()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards().OrderBy(ward => ward.Number).ToList();
            return View(new DisplayWardsViewModel { Wards = wards});
        }

        public ActionResult CreateNote(Guid id)
        {
            return View(new PatientCreateNoteViewModel {
                PatientUserId = id
            });
        }

        [HttpPost]
        public ActionResult CreateNote(PatientCreateNoteViewModel model)
        {
            var result = HospitalService.NotesBusinessLogic.CreateNote(new Note 
            { 
                NoteId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Content = model.NoteContent,
                PatientUserId = model.PatientUserId
            });

            return RedirectToAction("Details", new { id = model.PatientUserId });
        }

        public ActionResult RecordRefusal(Guid id)
        {
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);
            var procedures = HospitalService.ProcedureBusinessLogic.GetProceduresScheduledForPatientId(id);
            var coursesOfMedicines = HospitalService.CourseOfMedicineBusinessLogic.GetProceduresScheduledForPatientId(id);

            return View(new PatientTreatmentsModel
            {
                Patient = patient,
                Procedures = procedures,
                CoursesOfMedicines = coursesOfMedicines
            });
        }
    }
}