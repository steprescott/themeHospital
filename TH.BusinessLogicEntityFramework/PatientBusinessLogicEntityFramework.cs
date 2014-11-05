using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework
{
    public class PatientBusinessLogicEntityFramework : IPatientBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Domain.User.Patient> GetAllUsers()
        {
            return _unitOfWork.GetAll<Patient>().Select(u => new Domain.User.Patient
            {
                UserId = u.UserId,
                Firstname = u.FirstName,
                Surname = u.LastName,
                DateOfBirth = u.DateOfBirth,
                OtherNames = u.OtherNames,
                ContactNumber = u.ContactNumber,
                Addresses = u.Addresses.Select(a => new Domain.Address
                {
                    AddressId = a.AddressId,
                    LineOne = a.AddressLine1,
                    LineTwo = a.AddressLine2,
                    LineThree = a.AddressLine3,
                    City = a.City,
                    Postcode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList()
            });
        }
    }
}
