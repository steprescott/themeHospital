using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
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

        public List<Domain.Treatments.Operation> GetAllOperations()
        {
            var operations = _unitOfWork.GetAll<Operation>().ToList().OrderBy(o => o.Name);
            return operations.Select(o => ReflectiveMapperService.ConvertItem<Operation, Domain.Treatments.Operation>(o)).ToList();
        }

        public Domain.Treatments.Operation GetOperationById(Guid id)
        {
            Operation operation = _unitOfWork.GetById<Operation>(id);
            return ReflectiveMapperService.ConvertItem<Operation, Domain.Treatments.Operation>(operation);
        }
    }
}
