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

        public List<Domain.User.Doctor> GetAvailableDoctors()
        {
            var doctors = _unitOfWork.GetAll<Doctor>().ToList();

            //If the doctor isn't associated with a team and they the doctor isn't associated with an ongoing patient visit
            //then they are free to be part of another team
            doctors = doctors.Where(d => d.Team == null || d.Team.Visits.All(v => v.ReleaseDate == null)).ToList();

            return doctors.Select(d => ReflectiveMapperService.ConvertItem<Doctor, Domain.User.Doctor>(d))
                .ToList();
        }
    }
}
