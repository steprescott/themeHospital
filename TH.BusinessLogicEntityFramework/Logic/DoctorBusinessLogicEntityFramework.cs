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
        private IUnitOfWork _unitOfWork;

        public DoctorBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.User.Doctor> GetAvailableDoctors()
        {
            var doctors = _unitOfWork.GetAll<Doctor>();

            doctors = doctors.Where(d => d.Team == null);

            return doctors.Select(d => ReflectiveMapperService.ConvertItem<Doctor, Domain.User.Doctor>(d))
                .ToList();
        }
    }
}
