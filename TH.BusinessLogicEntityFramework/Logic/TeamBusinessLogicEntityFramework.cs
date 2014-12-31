using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class TeamBusinessLogicEntityFramework : ITeamBusinessLogic
    {
        private IUnitOfWork _unitOfWork;

        public TeamBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Other.Team GetTeamForDoctorId(Guid doctorId)
        {
            var doctor = _unitOfWork.GetById<Doctor>(doctorId);

            if (doctor != null && doctor.Team != null)
            {
                return ConvertToDomain(doctor.Team);
            }
            return null;
        }

        public List<Domain.User.Doctor> GetTeamMembersForConsultant(Guid consultantId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null)
            {
                return consultant.Team.Doctors
                    .Select(d => DoctorBusinessLogicEntityFramework.ConvertToDomain(d))
                    .ToList();
            }
            return null;
        }

        public List<Domain.Other.Team> GetAll()
        {
            var teams = _unitOfWork.GetAll<Team>().ToList();

            return teams.Select(t => ConvertToDomain(t)).ToList();
        }

        public static Procedure ConvertToEntityFramework(Domain.Other.Team procedure)
        {
            return new Procedure
            {

            };
        }

        public static Domain.Other.Team ConvertToDomain(Team procedure)
        {
            return new Domain.Other.Team
            {

            };
        }
    }
}
