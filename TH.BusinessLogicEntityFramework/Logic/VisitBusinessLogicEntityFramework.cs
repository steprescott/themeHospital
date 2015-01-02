using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class VisitBusinessLogicEntityFramework : IVisitBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Other.Visit GetVisitWithId(Guid id)
        {
            var visit = _unitOfWork.GetById<Visit>(id);

            return ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(visit);
        }

        public List<Domain.User.StaffMember> GetMedicalStaffForVisitWithId(Guid visitId)
        {
            var visit = _unitOfWork.GetById<Visit>(visitId);
            if (visit != null)
            {
                List<StaffMember> doctors = visit.Teams.SelectMany(t => t.Doctors).Select(d => d as StaffMember).ToList();
                List<StaffMember> consultants = visit.Teams.Select(t => t.Consultant).Select(c => c as StaffMember).ToList();

                var medicalStaff = doctors.Concat(consultants);
                var domainMedicalStaff = ReflectiveMapperService.ConvertItem<List<StaffMember>, List<Domain.User.StaffMember>>(medicalStaff.ToList());
                return domainMedicalStaff.OrderBy(o => o.Firstname).ToList();

            }
            return new List<Domain.User.StaffMember>();
        }

        public List<Domain.Other.Visit> GetAllPatientsWithOpenVisits()
        {
            var visits = _unitOfWork.GetAll<Visit>();

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(v, 6)).ToList();
        }

        public List<Domain.Other.Visit> GetOpenVisitsForDoctorId(Guid doctorId)
        {
            var visits = _unitOfWork.GetAll<Visit>();
            
            visits = visits.Where(v => v.Teams.SelectMany(t => t.Doctors).Select(d => d.UserId).Contains(doctorId));

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(v, 6)).ToList();
        }
        public List<Domain.Other.Visit> GetOpenVisitsForConsultantId(Guid consultantId)
        {
            var visits = _unitOfWork.GetAll<Visit>();
            
            visits = visits.Where(v => v.Teams.Select(t => t.Consultant).Select(d => d.UserId).Contains(consultantId));

            visits = visits.Where(v => v.ReleaseDate == null);

            return visits.ToList().Select(v => ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(v, 6)).ToList();
        }
    }
}
