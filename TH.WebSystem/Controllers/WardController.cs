using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Wards;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class WardController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards();

            return View(new WardViewModel { 
                Wards = wards
            });
        }

        public ActionResult Details(Guid id)
        {
            var ward = HospitalService.WardBusinessLogic.GetWardWithId(id);
            return View(new WardDetailsViewModel { 
                Ward = ward
            });
        }
        public ActionResult AssignToWard(Guid id)
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards();
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);
            return View(new AssignToWardViewModel { Wards = wards, PatientId = id});
        }

        public ActionResult AddToWaitingList(Guid wardId, Guid patientId)
        {
            var ward = HospitalService.WardBusinessLogic.GetWardWithId(wardId);

            var result = HospitalService.WardBusinessLogic.AssignPatientToWardWaitingList(ward.WardId, patientId);

            return RedirectToAction("Details", "Ward", new { id = ward.WardId});
        }
    }
}