using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
            var medicalStaffForPatient = HospitalService.VisitBusinessLogic.MedicalStaffForVisitWithId(id);
            var operations = HospitalService.OperationBusinessLogic.GetAllOperations();
            var currentUser = ThemeHospitalMembershipProvider.GetCurrentUser();

            return View(new CreateTreatmentViewModel()
            {
                MedicalStaff = medicalStaffForPatient,
                Operations = operations,
                VisitId = id,
                DateAdministered = DateTime.Now,
                ScheduledDate = DateTime.Now,
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
                OperationId = model.SelectedOperationId,
                ScheduledDate = model.ScheduledDate,
                DateAdministered = model.DateAdministered,
                RecordedByUserId = model.RecordedByStaffMemberId,
                AdministeredByUserId = model.AdministeredByStaffMemberId,
                VisitId = model.VisitId,
                Notes = new List<Note>()
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
            return View();
        }
    }
}