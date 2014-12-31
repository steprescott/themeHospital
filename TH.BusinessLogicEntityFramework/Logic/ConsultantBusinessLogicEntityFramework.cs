using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class ConsultantBusinessLogicEntityFramework : IConsultantBusinessLogic
    {
        private IUnitOfWork _unitOfWork;

        public ConsultantBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.User.Consultant GetConsultantForDoctorId(Guid doctorId)
        {
            var doctor = _unitOfWork.GetById<Doctor>(doctorId);

            if (doctor != null && doctor.Team != null && doctor.Team.Consultant != null)
            {
                return ConvertToDomain(doctor.Team.Consultant);
            }
            return null;
        }

        public Domain.Other.Team GetTeamForConsultantId(Guid consultantId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null)
            {
                return TeamBusinessLogicEntityFramework.ConvertToDomain(consultant.Team);
            }
            return null;
        }

        public bool AddDoctorToConsultantTeam(Guid consultantId, Guid doctorId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null && consultant.Team != null)
            {
                var doctorToAdd = _unitOfWork.GetById<Doctor>(doctorId);

                if (doctorToAdd != null)
                {
                    var consultantTeam = consultant.Team;
                    consultantTeam.Doctors.Add(doctorToAdd);

                    try
                    {
                        _unitOfWork.Update(consultantTeam);
                        _unitOfWork.SaveChanges();
                        return true;
                    }
                    catch (Exception exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool RemoveDoctorFromConsultantTeam(Guid consultantId, Guid doctorId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null && consultant.Team != null && consultant.Team.Doctors.Any())
            {
                var consultantTeam = consultant.Team;
                var doctorToRemove = consultantTeam.Doctors.SingleOrDefault(d => d.UserId == doctorId);

                if (doctorToRemove != null)
                {
                    consultantTeam.Doctors.Remove(doctorToRemove);
                }

                try
                {
                    _unitOfWork.Update(consultantTeam);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
            return false;
        }

        public static Consultant ConvertToEntityFramework(Domain.User.Consultant consultant)
        {
            return new Consultant
            {
                UserId = consultant.UserId,
                FirstName = consultant.Firstname,
                LastName = consultant.LastName,
                OtherNames = consultant.OtherNames,
                DateCreated = consultant.DateCreated,
                DateOfBirth = consultant.DateOfBirth,
                ContactNumber = consultant.ContactNumber,
                Gender = consultant.Gender,
                Addresses = consultant.Addresses.Select(a => new Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList(),
                Username = consultant.Username,
                LastLoggedIn = consultant.LastLoggedIn
            };
        }

        public static Domain.User.Consultant ConvertToDomain(Consultant consultant)
        {
            return new Domain.User.Consultant
            {
                UserId = consultant.UserId,
                Firstname = consultant.FirstName,
                LastName = consultant.LastName,
                OtherNames = consultant.OtherNames,
                DateCreated = consultant.DateCreated,
                DateOfBirth = consultant.DateOfBirth,
                ContactNumber = consultant.ContactNumber,
                Gender = consultant.Gender,
                Addresses = consultant.Addresses.Select(a => new Domain.Other.Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList(),
                Username = consultant.Username,
                LastLoggedIn = consultant.LastLoggedIn
            };
        }
    }
}
