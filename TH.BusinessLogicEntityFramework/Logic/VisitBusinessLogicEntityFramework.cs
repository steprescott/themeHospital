using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Interfaces;
using TH.ReflectiveMapper;
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
            var visit = _unitOfWork.GetById<Visit>(id);

            return ReflectiveMapperService.ConvertItem<Visit, Domain.Other.Visit>(visit);
        }

        public List<Domain.User.StaffMember> MedicalStaffForVisitWithId(Guid id)
        {
            var visit = _unitOfWork.GetById<Visit>(id);
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
    }
}
