using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Enums;
using TH.WebSystem.Models;
using TH.WebSystem.Providers;

namespace TH.WebSystem.Controllers
{
    public class ConsultantController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTeam()
        {
            var consultantId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            var team = HospitalService.ConsultantBusinessLogic.GetTeamForConsultantId(consultantId);

            return View(team);
        }

        public ActionResult AddDoctor()
        {
            var consultantId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            var availableDoctors = HospitalService.DoctorBusinessLogic.GetAvailableDoctorsForConsultantsTeam(consultantId);

            return View(availableDoctors);
        }

        public ActionResult AddToTeam(Guid doctorId)
        {
            var consultantId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            HospitalService.ConsultantBusinessLogic.AddDoctorToConsultantTeam(consultantId, doctorId);

            return RedirectToAction("AddDoctor");
        }

        public ActionResult RemoveDoctor(Guid doctorId)
        {
            var consultantId = ThemeHospitalMembershipProvider.GetCurrentUser().UserId;

            //Not doing anything for now if there is no result
            HospitalService.ConsultantBusinessLogic.RemoveDoctorFromConsultantTeam(consultantId, doctorId);

            return RedirectToAction("ViewTeam");
        }

        public ActionResult ManageTeam()
        {
            return View();
        }
    }
}