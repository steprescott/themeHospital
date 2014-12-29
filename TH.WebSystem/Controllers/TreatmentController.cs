using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Treatment;
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

        public ActionResult NewTreatment()
        {
            var operations = HospitalService.TreatmentBusinessLogic.GetAllOperations();
            return View(new NewTreatmentViewModel() { 
                Operations = operations
            });
        }

        [HttpPost]
        public ActionResult NewProcedure(NewTreatmentViewModel model) 
        {
            var opertation = HospitalService.TreatmentBusinessLogic.GetOperationById(model.SelectedOperationId);
            var procedure = new Domain.Treatment.Procedure() {
                TreatmentId = Guid.NewGuid(),
                ScheduledDate = model.ScheduledDate,
                DateAdministered = model.DateAdministered,
                Operation = opertation
            };

            HospitalService.TreatmentBusinessLogic.InsertProcedure(procedure);

            return View("Index");
        }

        [HttpPost]
        public ActionResult NewCourseOfMedicine(NewTreatmentViewModel model)
        {
            return View();
        }
    }
}