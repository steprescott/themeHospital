using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using Operation = TH.Domain.Treatments.Operation;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class OperationBusinessLogic : IOperationBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateOperation(Operation operation)
        {
            var efObject = _unitOfWork.GetById<UnitOfWorkEntityFramework.Operation>(operation.OperationId);

            try
            {
                if (efObject == null)
                {
                    efObject = new UnitOfWorkEntityFramework.Operation
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
                _unitOfWork.Delete(_unitOfWork.GetById<UnitOfWorkEntityFramework.Operation>(operationId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Operation> GetAllOperations()
        {
            var operations = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Operation>().ToList().OrderBy(o => o.Name);
            return operations.Select(o => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Operation, Operation>(o)).ToList();
        }

        public Operation GetOperationById(Guid id)
        {
            UnitOfWorkEntityFramework.Operation operation = _unitOfWork.GetById<UnitOfWorkEntityFramework.Operation>(id);
            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Operation, Operation>(operation);
        }
    }
}
