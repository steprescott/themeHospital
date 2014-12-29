using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Other;
using TH.Domain.Treatments;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class TreatmentController : AuthorisedBaseController
    {
        // GET: Treatment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var operations = HospitalService.TreatmentBusinessLogic.GetAllOperations();

            return View(new CreateTreatmentViewModel()
            {
                Operations = operations
            });
        }

        [HttpPost]
        public ActionResult CreateProcedure(CreateTreatmentViewModel model)
        {
            var procedure = new Procedure()
            {
                TreatmentId = Guid.NewGuid(),
                ScheduledDate = model.ScheduledDate,
                DateAdministered = model.DateAdministered,
                OperationId = model.SelectedOperationId,
                Notes = new List<Note>
                {
                     new Note
                    {
                        NoteId = Guid.NewGuid(),
                        Content = model.NoteContent,
                        DateCreated = DateTime.Now,
                    }
                },
            };

            HospitalService.TreatmentBusinessLogic.CreateProcedure(procedure);

            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateCourseOfMedicine(CreateTreatmentViewModel model)
        {
            return View();
        }
    }
}