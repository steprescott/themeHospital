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
            var procedures = _unitOfWork.GetAll<Procedure>();

            procedures = procedures.Where(com => com.AdministeredByUserId == userId);

            return procedures.Select(com => ReflectiveMapperService.ConvertItem<Procedure, Domain.Treatments.Procedure>(com))
                .ToList();
        }
    }
}
