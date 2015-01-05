using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using Doctor = TH.Domain.User.Doctor;
using Team = TH.Domain.Other.Team;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class TeamBusinessLogic : ITeamBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Team GetTeamForDoctorId(Guid doctorId)
        {
            var doctor = _unitOfWork.GetById<UnitOfWorkEntityFramework.Doctor>(doctorId);

            if (doctor != null && doctor.Team != null)
            {
                return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Team, Team>(doctor.Team);
            }
            return null;
        }

        public List<Doctor> GetTeamMembersForConsultant(Guid consultantId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null)
            {
                return consultant.Team.Doctors
                    .Select(d => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Doctor, Doctor>(d))
                    .ToList();
            }
            return null;
        }

        public List<Team> GetAll()
        {
            var teams = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Team>().ToList();

            return teams.Select(t => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Team, Team>(t)).ToList();
        }
    }
}
