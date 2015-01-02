using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var medicalStaff = HospitalService.VisitBusinessLogic.MedicalStaffForVisitWithId(visit.VisitId);
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
    }
}