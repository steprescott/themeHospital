using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
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

        public List<Domain.User.Doctor> GetAvailableDoctorsForConsultantsTeam(Guid userId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(userId);
            var doctors = _unitOfWork.GetAll<Doctor>().ToList();

            if (consultant != null && consultant.Team != null)
            {
                //First remove all the doctors that aren't already on the team of the current doctor
                doctors = doctors.Where(d => !consultant.Team.Doctors.Contains(d)).ToList();
            }

            //If the doctor isn't associated with a team and they the doctor isn't associated with an ongoing patient visit
            //then they are free to be part of another team
            doctors = doctors.Where(d => d.Team == null || (d.Team != null && d.Team.Visits.All(v => v.ReleaseDate != null))).ToList();

            return doctors.Select(d => ReflectiveMapperService.ConvertItem<Doctor, Domain.User.Doctor>(d))
                .ToList();
        }
    }
}
