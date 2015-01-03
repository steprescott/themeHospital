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
        public ActionResult AssignToWard(Guid id)
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards();
            var patient = HospitalService.PatientBusinessLogic.GetPatientWithId(id);
            return View(new AssignToWardViewModel { Wards = wards, PatientId = id});
        }

        public ActionResult WaitingList()
        {
            var patients = HospitalService.PatientBusinessLogic.GetAllPatients().ToList();

            return View(new DisplayWardWaitingListViewModel { Patients = patients });
        }

        public ActionResult AddToWaitingList(Guid wardId, Guid patientId)
        {
            var ward = HospitalService.WardBusinessLogic.GetWardWithId(wardId);

            var result = HospitalService.WardBusinessLogic.AssignPatientToWardWaitingList(ward.WardWaitlingList.WardWaitingListId, patientId);

            return RedirectToAction("WaitingList", "Ward");
        }
    }
}