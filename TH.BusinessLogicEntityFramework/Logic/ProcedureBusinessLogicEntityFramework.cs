using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
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
                Procedure efObject = ConvertToEntityFramework(procedure);
                _unitOfWork.Insert(efObject); 
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static Procedure ConvertToEntityFramework(Domain.Treatments.Procedure procedure)
        {
            return new Procedure 
            { 
                TreatmentId = procedure.TreatmentId,
                OperationId = procedure.OperationId,
                ScheduledDate = procedure.ScheduledDate,
                VisitId = procedure.VisitId,
                RecordedByUserId = procedure.RecordedByUserId,
                AdministeredByUserId = procedure.AdministeredByUserId,
                DateAdministered = procedure.DateAdministered,
            };
        }

        public static Domain.Treatments.Procedure ConvertToDomain(Procedure procedure)
        {
            return new Domain.Treatments.Procedure
            {
                TreatmentId = procedure.TreatmentId,
                OperationId = procedure.OperationId,
                ScheduledDate = procedure.ScheduledDate,
                VisitId = procedure.VisitId,
                RecordedByUserId = procedure.RecordedByUserId,
                AdministeredByUserId = procedure.AdministeredByUserId,
                DateAdministered = procedure.DateAdministered,
            }; 
        }
    }
}
