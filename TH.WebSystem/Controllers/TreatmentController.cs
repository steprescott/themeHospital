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

            return View(new CreateTreatmentViewModel()
            {
                MedicalStaff = medicalStaffForPatient,
                Operations = operations,
                VisitId = id,
                DateAdministered = DateTime.Now,
                ScheduledDate = DateTime.Now
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
                RecordedByUserId = model.AdministeredByStaffMemberId,
                AdministeredByUserId = model.AdministeredByStaffMemberId,
                VisitId = model.VisitId,
                Notes = new List<Note>()
            };

            if(!String.IsNullOrEmpty(model.NoteContent))
            {
                HospitalService.NotesBusinessLogic.CreateNote(new Note
                {
                    NoteId = Guid.NewGuid(),
                    Content = model.NoteContent,
                    DateCreated = DateTime.Now,
                    Treatment = procedure
                });
            }

            HospitalService.ProcedureBusinessLogic.CreateProcedure(procedure);

            return RedirectToAction("Options", "Patient", new { id = visit.Patient.UserId });
        }

        [HttpPost]
        public ActionResult CreateCourseOfMedicine(CreateTreatmentViewModel model)
        {
            return View();
        }
    }
}