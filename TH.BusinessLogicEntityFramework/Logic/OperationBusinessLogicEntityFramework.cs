using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class OperationBusinessLogicEntityFramework : IOperationBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateOperation(Domain.Treatments.Operation operation)
        {
            try
            {
                var efOperation = _unitOfWork.GetById<Operation>(operation.OperationId);

                if (efOperation == null)
                {
                    efOperation = new Operation
                    {
                        OperationId = operation.OperationId != null ? operation.OperationId : Guid.NewGuid()
                    };

                    _unitOfWork.Insert(efOperation);
                }

                efOperation.Name = operation.Name;
                efOperation.Description = operation.Description;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteOperationWithId(Guid operationId)
        {
            try
            {
                _unitOfWork.Delete(_unitOfWork.GetById<Operation>(operationId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
