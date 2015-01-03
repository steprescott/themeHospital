using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using StaffMember = TH.Domain.User.StaffMember;
using Visit = TH.Domain.Other.Visit;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class VisitBusinessLogicEntityFramework : IVisitBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Visit GetVisitWithId(Guid id)
        {
            var visit = _unitOfWork.GetById<UnitOfWorkEntityFramework.Visit>(id);

            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Visit, Visit>(visit);
        }

        public List<StaffMember> GetMedicalStaffForVisitWithId(Guid visitId)
        {
            var visit = _unitOfWork.GetById<UnitOfWorkEntityFramework.Visit>(visitId);
            if (visit != null)
            {
                List<UnitOfWorkEntityFramework.StaffMember> doctors = visit.Teams.SelectMany(t => t.Doctors).Select(d => d as UnitOfWorkEntityFramework.StaffMember).ToList();
                List<UnitOfWorkEntityFramework.StaffMember> consultants = visit.Teams.Select(t => t.Consultant).Select(c => c as UnitOfWorkEntityFramework.StaffMember).ToList();

                var medicalStaff = doctors.Concat(consultants);
                var domainMedicalStaff = ReflectiveMapperService.ConvertItem<List<UnitOfWorkEntityFramework.StaffMember>, List<StaffMember>>(medicalStaff.ToList());
                return domainMedicalStaff.OrderBy(o => o.FirstName).ToList();

            }
            return new List<StaffMember>();
        }

        public List<Visit> GetAllPatientsWithOpenVisits()
        {
            var visits = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Visit>();

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Visit, Visit>(v, 6)).ToList();
        }

        public List<Visit> GetOpenVisitsForDoctorId(Guid doctorId)
        {
            var visits = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Visit>();
            
            visits = visits.Where(v => v.Teams.SelectMany(t => t.Doctors).Select(d => d.UserId).Contains(doctorId));

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Visit, Visit>(v, 6)).ToList();
        }
        public List<Visit> GetOpenVisitsForConsultantId(Guid consultantId)
        {
            var visits = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Visit>();
            
            visits = visits.Where(v => v.Teams.Select(t => t.Consultant).Select(d => d.UserId).Contains(consultantId));

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Visit, Visit>(v, 6)).ToList();
        }
    }
}
