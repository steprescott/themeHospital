using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
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

            return patients.Select(p => ConvertToDomain(p));
        }

        public Domain.User.Patient GetPatientWithId(Guid userId)
        {
            var patient = _unitOfWork.GetById<Patient>(userId);

            return ConvertToDomain(patient);
        }

        public bool InsertOrUpdatePatient(Domain.User.Patient domainPatient)
        {
            var patient = _unitOfWork.GetById<Patient>(domainPatient.UserId);

            if (patient == null)
            {
                domainPatient.UserId = domainPatient.UserId == Guid.Empty ? Guid.NewGuid() : domainPatient.UserId;
                domainPatient.DateCreated = DateTime.Now;
            }

            try
            {
                patient = ConvertToEntityFramework(domainPatient);

                _unitOfWork.Insert(patient);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception exception)
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
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Domain.User.Patient> SearchPatient(string searchText)
        {
            var matchedPatients = new List<Patient>();
            searchText = searchText.ToLower();

            var patients = _unitOfWork.GetAll<Patient>();

            foreach (var patient in patients)
            {
                if (patient.FirstName.ToLower().Contains(searchText))
                {
                    matchedPatients.Add(patient);
                }
                else if (patient.LastName.ToLower().Contains(searchText))
                {
                    matchedPatients.Add(patient);
                }
                else if (patient.FullName().ToLower().Contains(searchText))
                {
                    matchedPatients.Add(patient);
                }
            }
            return matchedPatients.Select(p => ConvertToDomain(p)).ToList();
        }


        public bool PatientHasOpenVisit(Guid patientId)
        {
            var patient = _unitOfWork.GetById<Patient>(patientId);

            if (patient != null)
            {
                return patient.Visits.Any(v => v.ReleaseDate == null);
            }
            return false;
        }

        public bool AdmitPatient(Guid patientId, Guid teamId)
        {
            var patient = _unitOfWork.GetById<Patient>(patientId);
            var team = _unitOfWork.GetById<Team>(teamId);

            if (patient != null && team != null)
            {
                if (patient.Visits.All(v => v.ReleaseDate != null))
                {
                    var visit = new Visit
                    {
                        VisitId = Guid.NewGuid(),
                        Patient = patient,
                        Teams = new Collection<Team>
                        {
                            team
                        },
                        AdmittedDate = DateTime.Now,
                        ReleaseDate = null
                    };

                    try
                    {
                        _unitOfWork.Insert(visit);
                        _unitOfWork.SaveChanges();

                        return true; ;
                    }
                    catch (Exception exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool DismissPatient(Guid patientId)
        {
            var patient = _unitOfWork.GetById<Patient>(patientId);

            if (patient != null && PatientHasOpenVisit(patientId))
            {
                var visit = patient.Visits.Single(v => v.ReleaseDate == null);
                visit.ReleaseDate = DateTime.Now;

                try
                {
                    _unitOfWork.Update(visit);
                    _unitOfWork.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public static Patient ConvertToEntityFramework(Domain.User.Patient patient, bool solvedNested = false)
        {
            return new Patient
            {
                UserId = patient.UserId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                OtherNames = patient.OtherNames,
                DateCreated = patient.DateCreated,
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactNumber = patient.EmergencyContactNumber,
                Gender = patient.Gender,
                Addresses = patient.Addresses.Select(a => new Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList()
            };
        }

        public static Domain.User.Patient ConvertToDomain(Patient patient, bool solvedNested = false)
        {
            return new Domain.User.Patient
            {
                UserId = patient.UserId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                OtherNames = patient.OtherNames,
                DateCreated = patient.DateCreated,
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactNumber = patient.EmergencyContactNumber,
                Gender = patient.Gender,
                Addresses = patient.Addresses.Select(a => new Domain.Other.Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList()
            };
        }
    }
}
