using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework
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
            return ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(_unitOfWork.GetById<Visit>(id));
        }

        public List<Domain.User.StaffMember> MedicalStaffForVisitWithId(Guid id)
        {
            var visit = GetVisitWithId(id);
            var efVisit = ReflectiveMapperService.ConvertItem<Domain.Other.Visit, Visit>(visit);
            List<StaffMember> doctors = efVisit.Teams.SelectMany(t => t.Doctors).Select(d => d as StaffMember).ToList();
            List<StaffMember> consultants = efVisit.Teams.Select(t => t.Consultant).Select(c => c as StaffMember).ToList();

            var medicalStaff = doctors.Concat(consultants);
            var efMedicalStaff = ReflectiveMapperService.ConvertItem<List<StaffMember>, List<Domain.User.StaffMember>>(medicalStaff.ToList());
            return efMedicalStaff;
        }
    }
}
