using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class WardController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards();

            return View(new WardViewModel 
            { 
                Wards = wards
            });
        }

        public ActionResult Details(Guid id)
        {
            var ward = HospitalService.WardBusinessLogic.GetWardWithId(id);

            return View(new WardDetailsViewModel 
            { 
                Ward = ward
            });
        }
        public ActionResult AssignToWard(Guid id)
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards();

            return View(new AssignToWardViewModel 
            { 
                Wards = wards, 
                PatientId = id
            });
        }

        public ActionResult AddToWaitingList(Guid wardId, Guid patientId)
        {
            HospitalService.WardBusinessLogic.AssignPatientToWardWaitingList(wardId, patientId);

            return RedirectToAction("Details", "Ward", new { id = wardId});
        }
    }
}