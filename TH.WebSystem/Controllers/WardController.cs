using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.WebSystem.Models;
using TH.WebSystem.Services;

namespace TH.WebSystem.Controllers
{
    public class WardController : AuthorisedBaseController
    {
        // GET: Ward
        public ActionResult DisplayWards()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards().OrderBy(ward => ward.Number).ToList();
            return View(new DisplayWardsViewModel { Wards = wards });
        }

        public ActionResult WaitingList()
        {
            var wards = HospitalService.WardBusinessLogic.GetAllWards().OrderBy(ward => ward.Number).ToList();
            var patients = HospitalService.PatientBusinessLogic.GetAllPatients().ToList();

            return View(new DisplayWardWaitingListViewModel { Wards = wards, Patients = patients });
        }
        public ActionResult WaitingList(Guid patientId)
        {
            return View();
        }
    }
}