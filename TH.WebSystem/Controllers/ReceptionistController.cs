using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Domain.Other;
using TH.Domain.User;
using TH.WebSystem.Models;

namespace TH.WebSystem.Controllers
{
    public class ReceptionistController : AuthorisedBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            return View(new AddPatientViewModel());
        }

        [HttpPost]
        public ActionResult AddPatient(AddPatientViewModel patient)
        {
            HospitalService.PatientBusinessLogic.InsertOrUpdatePatient(new Patient
            {
                Firstname = patient.FirstName,
                OtherNames = patient.OtherNames,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                ContactNumber = patient.ContactNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactNumber = patient.EmergencyContactNumber,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressId = Guid.NewGuid(),
                        AddressLine1 = patient.Address.LineOne,
                        AddressLine2 = patient.Address.LineTwo,
                        AddressLine3 = patient.Address.LineThree,
                        City = patient.Address.City,
                        PostCode = patient.Address.Postcode,
                        IsCurrentAddress = true
                    }
                }
            });

            return RedirectToAction("Index", "Patient");
        }
    }
}