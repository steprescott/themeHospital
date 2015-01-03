using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Other;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class VisitController : AuthorisedBaseController
    {
        public ActionResult Details(Guid id)
        {
            var visit = HospitalService.VisitBusinessLogic.GetVisitWithId(id);
            var procedures = HospitalService.ProcedureBusinessLogic.GetProceduresScheduledForPatientId(visit.Patient.UserId)
                .Where(p => p.VisitId == id);
            var courseOfMedicines = HospitalService.CourseOfMedicineBusinessLogic.GetCourseOfMedicinesScheduledForPatientId(visit.Patient.UserId)
                .Where(com => com.VisitId == id);

            return View(new VisitDetailsViewModel 
            {
                Visit = visit,
                Procedures = procedures.ToList(),
                CourseOfMedicines = courseOfMedicines.ToList()
            });
        }

        public ActionResult CreateNote(Guid id)
        {
            return View(new VisitCreateNoteViewModel
            {
                VisitId = id
            });
        }

        [HttpPost]
        public ActionResult CreateNote(VisitCreateNoteViewModel model)
        {
            var result = HospitalService.NotesBusinessLogic.CreateNote(new Note
            {
                NoteId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                Content = model.NoteContent,
                VisitId = model.VisitId
            });

            return RedirectToAction("Details", new { id = model.VisitId });
        }
    }
}