using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Enums;
using TH.Domain.Other;
using TH.Domain.Treatments;
using TH.WebSystem.Models;
using TH.WebSystem.Providers;

namespace TH.WebSystem.Controllers
{
    public class TreatmentController : AuthorisedBaseController
    {
        // GET: Treatment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid id)
        {
            var visit = HospitalService.VisitBusinessLogic.GetVisitWithId(id);
            var medicalStaff = HospitalService.VisitBusinessLogic.GetMedicalStaffForVisitWithId(visit.VisitId);
            var operations = HospitalService.OperationBusinessLogic.GetAllOperations();
            var medicines = HospitalService.MedicneBusinessLogic.GetAllMedicines();
            var currentUser = ThemeHospitalMembershipProvider.GetCurrentUser();

            return View(new CreateTreatmentViewModel()
            {
                MedicalStaff = medicalStaff,
                Operations = operations,
                Medicines = medicines,
                PatientFullName = visit.Patient.FullName,
                VisitId = id,
                ScheduledDate = DateTime.Now,
                EndDate = DateTime.Now,
                RecordedByStaffMemberId = currentUser.UserId
            });
        }

        [HttpPost]
        public ActionResult CreateProcedure(CreateTreatmentViewModel model)
        {
            var visit = HospitalService.VisitBusinessLogic.GetVisitWithId(model.VisitId);

            var procedure = new Procedure()
            {
                TreatmentId = Guid.NewGuid(),
                ScheduledDate = model.ScheduledDate,
                RecordedByUserId = model.RecordedByStaffMemberId,
                AssignedToUserId = model.AssignedToStaffMemberId,
                VisitId = model.VisitId,
                Notes = new List<Note>(),

                OperationId = model.SelectedOperationId
            };

            var result = HospitalService.ProcedureBusinessLogic.CreateProcedure(procedure);

            if(result && !String.IsNullOrEmpty(model.NoteContent))
            {
                var noteResult = HospitalService.NotesBusinessLogic.CreateNote(new Note
                {
                    NoteId = Guid.NewGuid(),
                    Content = model.NoteContent,
                    DateCreated = DateTime.Now,
                    TreatmentId = procedure.TreatmentId
                });
            }

            return RedirectToAction("Options", "Patient", new { id = visit.Patient.UserId });
        }

        [HttpPost]
        public ActionResult CreateCourseOfMedicine(CreateTreatmentViewModel model)
        {
            var visit = HospitalService.VisitBusinessLogic.GetVisitWithId(model.VisitId);

            var courseOfMedicine = new CourseOfMedicine {
                TreatmentId = Guid.NewGuid(),
                ScheduledDate = model.ScheduledDate,
                RecordedByUserId = model.RecordedByStaffMemberId,
                AssignedToUserId = model.AssignedToStaffMemberId,
                VisitId = model.VisitId,
                Notes = new List<Note>(),

                EndDate = model.EndDate,
                Instructions = model.Instructions,
                MedicineId = model.SelectedMedicineId
            };

            var result = HospitalService.CourseOfMedicineBusinessLogic.CreateCauseOfMedicne(courseOfMedicine);

            if (result && !String.IsNullOrEmpty(model.NoteContent))
            {
                var noteResult = HospitalService.NotesBusinessLogic.CreateNote(new Note
                {
                    NoteId = Guid.NewGuid(),
                    Content = model.NoteContent,
                    DateCreated = DateTime.Now,
                    TreatmentId = courseOfMedicine.TreatmentId
                });
            }

            return RedirectToAction("Options", "Patient", new { id = visit.Patient.UserId });
        }

        [HttpPost]
        public ActionResult AdministorProcedure(ProcedureViewModel model)
        {
            var result = HospitalService.ProcedureBusinessLogic.AdministorProcedureWithId(model.TreatmentId, model.AdministeredByUserId);
            return RedirectToAction("Procedure", new { id = model.TreatmentId });
        }
        
        [HttpPost]
        public ActionResult AdministorCourseOfMedicine(ProcedureViewModel model)
        {
            var result = HospitalService.CourseOfMedicineBusinessLogic.AdministorCourseOfMedicineWithId(model.TreatmentId, model.AdministeredByUserId);
            return RedirectToAction("CourseOfMedicine", new { id = model.TreatmentId });
        }

        public ActionResult RefuseTreatment(Guid id)
        {
            var treatmentName = HospitalService.TreatmentBusinessLogic.GetTreatmentName(id);
            var treatment = HospitalService.TreatmentBusinessLogic.GetTreatmentById(id);

            return View(new RefuseTreatmentModel
            {
                TreatmentId = id,
                TreatmentName = treatmentName,
                PatientId = treatment.Visit.Patient.UserId,
                PatientName = treatment.Visit.Patient.FullName
            });
        }

        [HttpPost]
        public ActionResult RefuseTreatment(RefuseTreatmentModel refuseTreatmentModel)
        {
            var result = HospitalService.TreatmentBusinessLogic.RecordRefusalOfTreatment(refuseTreatmentModel.TreatmentId,
                refuseTreatmentModel.RefusalReason);

            return RedirectToAction("Options", "Patient", new { id = refuseTreatmentModel.PatientId });
        }

        public ActionResult ViewTreatments()
        {
            var userId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            var assignedProcedures = HospitalService.ProcedureBusinessLogic.GetProceduresToBeAdministeredByStaffMemberId(userId);
            var assignedCoursesOfMedicine = HospitalService.CourseOfMedicineBusinessLogic.GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(userId);

            if (ThemeHospitalMembershipProvider.GetUserRole() == StaffType.Consultant)
            {
                var teamsAssignedProcedures = HospitalService.ProcedureBusinessLogic.GetProceduresForTeamByConsultantId(userId);
                var teamsAssignedCoursesOfMedicines = HospitalService.CourseOfMedicineBusinessLogic.GetCoursesOfMedicinesForTeamByConsultantId(userId);

                return View(new ViewTreatmentModel
                {
                    CoursesOfMedicines = assignedCoursesOfMedicine,
                    Procedures = assignedProcedures,
                    TeamsCourseOfMedicines = teamsAssignedCoursesOfMedicines,
                    TeamsProcedures = teamsAssignedProcedures
                });
            }

            return View(new ViewTreatmentModel
            {
                CoursesOfMedicines = assignedCoursesOfMedicine,
                Procedures = assignedProcedures
            });
        }

        public ActionResult Procedure(Guid id)
        {
            var procedure = HospitalService.ProcedureBusinessLogic.GetProcedureWithId(id);
            var recordedBy = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(procedure.RecordedByUserId);
            var assignedTo = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(procedure.AssignedToUserId);
            var administoredBy = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(procedure.AdministeredByUserId.GetValueOrDefault());
            var medicalStaff = HospitalService.VisitBusinessLogic.GetMedicalStaffForVisitWithId(procedure.Visit.VisitId);

            return View(new ProcedureViewModel {
                Procedure = procedure,
                RecordedBy = recordedBy,
                AssignedTo = assignedTo,
                MedicalStaff = medicalStaff,
                AdministeredBy = administoredBy,
                TreatmentId = procedure.TreatmentId
            });
        }

        public ActionResult CourseOfMedicine(Guid id)
        {
            var courseOfMedicine = HospitalService.CourseOfMedicineBusinessLogic.GetCoursesOfMedicineWithId(id);
            var recordedBy = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(courseOfMedicine.RecordedByUserId);
            var assignedTo = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(courseOfMedicine.AssignedToUserId);
            var administoredBy = HospitalService.StaffMemberBusinessLogic.GetStaffMemberWithId(courseOfMedicine.AdministeredByUserId.GetValueOrDefault());
            var medicalStaff = HospitalService.VisitBusinessLogic.GetMedicalStaffForVisitWithId(courseOfMedicine.Visit.VisitId);

            return View(new CourseOfMedicineViewModel
            {
                CourseOfMedicine = courseOfMedicine,
                RecordedBy = recordedBy,
                AssignedTo = assignedTo,
                MedicalStaff = medicalStaff,
                AdministeredBy = administoredBy,
                TreatmentId = courseOfMedicine.TreatmentId
            });
        }
    }
}