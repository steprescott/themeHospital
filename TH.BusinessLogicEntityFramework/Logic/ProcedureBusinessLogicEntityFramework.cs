using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
