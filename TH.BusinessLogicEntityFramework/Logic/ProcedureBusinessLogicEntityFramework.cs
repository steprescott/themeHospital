using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class ProcedureBusinessLogicEntityFramework : IProcedureBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateProcedure(Domain.Treatments.Procedure procedure)
        {
            try
            {
                Procedure efObject = ReflectiveMapperService.ConvertItem<Domain.Treatments.Procedure, Procedure>(procedure);
                _unitOfWork.Insert(efObject); 
                _unitOfWork.SaveChanges();
                return true;
            }
             catch (Exception exception)
            {
                return false;
            }
        }

        public List<Domain.Treatments.Procedure> GetProceduresToBeAdministeredByStaffMemberId(Guid userId)
        {
            var procedures = _unitOfWork.GetAll<Procedure>().ToList();

            procedures = procedures.Where(com => com.AssignedToUserId == userId).ToList();

            return procedures.Select(com => ReflectiveMapperService.ConvertItem<Procedure, Domain.Treatments.Procedure>(com))
                .ToList();
        }

        public List<Domain.Treatments.Procedure> GetProceduresForTeamByConsultantId(Guid userId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(userId);

            if (consultant != null)
            {
                var consultantTeam = consultant.Team;
                var coursesOfMedicines = _unitOfWork.GetAll<Procedure>().ToList();

                coursesOfMedicines = coursesOfMedicines.Where(com => consultantTeam.Doctors.Select(d => d.UserId).Contains(com.AssignedToUserId)).ToList();

                return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<Procedure, Domain.Treatments.Procedure>(com)).ToList();
            }
            return new List<Domain.Treatments.Procedure>();
        }

        public List<Domain.Treatments.Procedure> GetProceduresScheduledForPatientId(Guid patientId)
        {
            var procedures = _unitOfWork.GetAll<Procedure>().ToList();

            procedures = procedures.Where(p => p.Visit.PatientUserId == patientId).ToList();

            return procedures.Select(p => ReflectiveMapperService.ConvertItem<Procedure, Domain.Treatments.Procedure>(p)).ToList();
        }
    }
}
