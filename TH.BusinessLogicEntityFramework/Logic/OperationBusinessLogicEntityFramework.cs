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
            var efObject = _unitOfWork.GetById<Operation>(operation.OperationId);

            try
            {
                if (efObject == null)
                {
                    efObject = new Operation
                    {
                        OperationId = operation.OperationId != null ? operation.OperationId : Guid.NewGuid(),
                        Name = operation.Name,
                        Description = operation.Description,
                    };

                    _unitOfWork.Insert(efObject);
                }
                else
                {
                    efObject.Name = operation.Name;
                    efObject.Description = operation.Description;

                    _unitOfWork.Update(efObject);
                }

                _unitOfWork.SaveChanges();
                return true;

            }
            catch (Exception exception)
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
