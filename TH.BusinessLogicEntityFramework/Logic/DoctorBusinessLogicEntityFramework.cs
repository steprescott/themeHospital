using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class DoctorBusinessLogicEntityFramework : IDoctorBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.User.Doctor> GetAvailableDoctors()
        {
            var doctors = _unitOfWork.GetAll<Doctor>().ToList();

            //If the doctor isn't associated with a team and they the doctor isn't associated with an ongoing patient visit
            //then they are free to be part of another team
            doctors = doctors.Where(d => d.Team == null || d.Team.Visits.All(v => v.ReleaseDate == null)).ToList();

            return doctors.Select(d => ConvertToDomain(d, true)).ToList();
        }

        public static Doctor ConvertToEntityFramework(Domain.User.Doctor doctor, bool solvedNested = false)
        {
            var obj = new Doctor
            {
                UserId = doctor.UserId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                OtherNames = doctor.OtherNames,
                DateCreated = doctor.DateCreated,
                DateOfBirth = doctor.DateOfBirth,
                ContactNumber = doctor.ContactNumber,
                Gender = doctor.Gender,
                Username = doctor.Username,
                LastLoggedIn = doctor.LastLoggedIn,
            };

            if (solvedNested)
            {
                obj.Team = TeamBusinessLogicEntityFramework.ConvertToEntityFramework(doctor.Team);
            }

            return obj;
        }

        public static Domain.User.Doctor ConvertToDomain(Doctor doctor, bool solvedNested = false)
        {
            var obj = new Domain.User.Doctor
            {
                UserId = doctor.UserId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                OtherNames = doctor.OtherNames,
                DateCreated = doctor.DateCreated,
                DateOfBirth = doctor.DateOfBirth,
                ContactNumber = doctor.ContactNumber,
                Gender = doctor.Gender,
                Username = doctor.Username,
                LastLoggedIn = doctor.LastLoggedIn,
            };

            if (solvedNested)
            {
                obj.Team = TeamBusinessLogicEntityFramework.ConvertToDomain(doctor.Team);
            }

            return obj;
        }
    }
}
