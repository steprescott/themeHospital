﻿using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
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
                return ReflectiveMapperService.ConvertItem<Consultant, Domain.User.Consultant>(doctor.Team.Consultant);
            }
            return null;
        }

        public Domain.Other.Team GetTeamForConsultantId(Guid consultantId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(consultantId);

            if (consultant != null)
            {
                return ReflectiveMapperService.ConvertItem<Team, Domain.Other.Team>(consultant.Team);
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
    }
}
