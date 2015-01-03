using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using Procedure = TH.Domain.Treatments.Procedure;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class ProcedureBusinessLogicEntityFramework : IProcedureBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateProcedure(Procedure procedure)
        {
            try
            {
                UnitOfWorkEntityFramework.Procedure efObject = ReflectiveMapperService.ConvertItem<Procedure, UnitOfWorkEntityFramework.Procedure>(procedure);
                _unitOfWork.Insert(efObject); 
                _unitOfWork.SaveChanges();
                return true;
            }
             catch (Exception exception)
            {
                return false;
            }
        }

        public Procedure GetProcedureWithId(Guid id)
        {
            var procedure = _unitOfWork.GetById<UnitOfWorkEntityFramework.Procedure>(id);
            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Procedure, Procedure>(procedure);
        }

        public List<Procedure> GetProceduresToBeAdministeredByStaffMemberId(Guid userId)
        {
            var procedures = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Procedure>().ToList();

            procedures = procedures.Where(com => com.AssignedToUserId == userId).ToList();

            return procedures.Select(com => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Procedure, Procedure>(com))
                .ToList();
        }

        public List<Procedure> GetProceduresForTeamByConsultantId(Guid userId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(userId);

            if (consultant != null)
            {
                var consultantTeam = consultant.Team;
                var coursesOfMedicines = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Procedure>().ToList();

                coursesOfMedicines = coursesOfMedicines.Where(com => consultantTeam.Doctors.Select(d => d.UserId).Contains(com.AssignedToUserId)).ToList();

                return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Procedure, Procedure>(com)).ToList();
            }
            return new List<Procedure>();
        }

        public List<Procedure> GetProceduresScheduledForPatientId(Guid patientId)
        {
            var procedures = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Procedure>().ToList();

            procedures = procedures.Where(p => p.Visit.PatientUserId == patientId).ToList();

            return procedures.Select(p => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Procedure, Procedure>(p)).ToList();
        }

        public bool AdministorProcedureWithId(Guid id, Guid administoredByUserId)
        {
            try
            {
                var efProcedure = _unitOfWork.GetById<UnitOfWorkEntityFramework.Procedure>(id);
                efProcedure.DateAdministered = DateTime.Now;
                efProcedure.AdministeredByUserId = administoredByUserId;
                _unitOfWork.Update(efProcedure);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
