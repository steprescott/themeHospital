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

        public IEnumerable<Domain.User.Patient> GetAllPatients()
        {
            var patients = _unitOfWork.GetAll<Patient>().ToList();

            return patients.Select(EntityFrameworkToDomain);
        }

        public Domain.User.Patient GetPatientWithId(Guid userId)
        {
            return EntityFrameworkToDomain(_unitOfWork.GetById<Patient>(userId));
        }

        public bool InsertOrUpdatePatient(Domain.User.Patient domainPatient)
        {
            Patient patient = _unitOfWork.GetById<Patient>(domainPatient.UserId);

            if (patient == null)
            {
                domainPatient.UserId = Guid.NewGuid();
                domainPatient.DateCreated = DateTime.Now;
            }

            try
            {
                patient = DomainToEntityFramework(domainPatient);

                _unitOfWork.Insert(patient);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePatient(Domain.User.Patient domainPatient)
        {
            return DeletePatientWithId(domainPatient.UserId);
        }
        
        public bool DeletePatientWithId(Guid userId)
        {
            try
            {
                Patient patient = _unitOfWork.GetById<Patient>(userId);

                if (patient != null)
                {
                    _unitOfWork.Delete(patient);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Patient DomainToEntityFramework(Domain.User.Patient domainPatient)
        {
            var addresses = new List<Address>();

            foreach (var domainAddress in domainPatient.Addresses)
            {
                Address address = _unitOfWork.GetById<Address>(domainAddress.AddressId);

                if(address == null)
                {
                    address = new Address
                    {
                        AddressId = Guid.NewGuid()
                    };
                }

                address.AddressLine1 = domainAddress.AddressLine1;
                address.AddressLine2 = domainAddress.AddressLine2;
                address.AddressLine3 = domainAddress.AddressLine3;
                address.City = domainAddress.City;
                address.PostCode = domainAddress.PostCode;
                address.IsCurrentAddress = domainAddress.IsCurrentAddress;

                if (!addresses.Contains(address))
                {
                    addresses.Add(address);
                }
            }

            return new Patient
            {
                UserId = domainPatient.UserId,
                DateCreated = domainPatient.DateCreated,
                FirstName = domainPatient.Firstname,
                OtherNames = domainPatient.OtherNames,
                LastName = domainPatient.LastName,
                DateOfBirth = domainPatient.DateOfBirth,
                ContactNumber = domainPatient.ContactNumber,
                Gender = domainPatient.Gender,
                Addresses = addresses,

                EmergencyContactName = domainPatient.EmergencyContactName,
                EmergencyContactNumber = domainPatient.EmergencyContactNumber,
            };
        }

        private Domain.User.Patient EntityFrameworkToDomain(Patient patient)
        {
            var addresses = new List<Domain.Address>();

            foreach (var address in patient.Addresses)
            {
                var domainAddress = new Domain.Address
                {
                    AddressId = address.AddressId,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressLine3 = address.AddressLine3,
                    City = address.City,
                    PostCode = address.PostCode,
                    IsCurrentAddress = address.IsCurrentAddress,
                };

                if (!addresses.Contains(domainAddress))
                {
                    addresses.Add(domainAddress);
                }
            }

            return new Domain.User.Patient
            {
                UserId = patient.UserId,
                DateCreated = patient.DateCreated,
                Firstname = patient.FirstName,
                OtherNames = patient.OtherNames,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                Gender = patient.Gender,
                Addresses = addresses,

                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactNumber = patient.EmergencyContactNumber,
            };
        }
    }
}
