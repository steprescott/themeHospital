using System;
using System.Collections.Generic;
using System.Linq;
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
                var efObject = _unitOfWork.GetById<Operation>(operation.OperationId);

                if (efObject == null)
                {
                    efObject = new Operation {
                        OperationId = operation.OperationId != Guid.Empty ? operation.OperationId : Guid.NewGuid(),
                        Name = operation.Name,
                        Description = operation.Description
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
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public List<Domain.Treatments.Operation> GetAllOperations()
        {
            var operations = _unitOfWork.GetAll<Operation>().ToList().OrderBy(o => o.Name);
            return operations.Select(o => ConvertToDomain(o, true)).ToList();
        }

        public Domain.Treatments.Operation GetOperationById(Guid id)
        {
            Operation operation = _unitOfWork.GetById<Operation>(id);
            return ConvertToDomain(operation, true);
        }

        public static Operation ConvertToEntityFramework(Domain.Treatments.Operation operation, bool solvedNested = false)
        {
            var obj = new Operation
            {
                OperationId = operation.OperationId,
                Name = operation.Name,
                Description = operation.Description,
            };

            if (solvedNested)
            {
                obj.Procedures = operation.Procedures.Select(p => ProcedureBusinessLogicEntityFramework.ConvertToEntityFramework(p)).ToList();
            }

            return obj;
        }

        public static Domain.Treatments.Operation ConvertToDomain(Operation operation, bool solvedNested = false)
        {
            var obj = new Domain.Treatments.Operation
            {
                OperationId = operation.OperationId,
                Name = operation.Name,
                Description = operation.Description,
            };

            if (solvedNested)
            {
                obj.Procedures = operation.Procedures.Select(p => ProcedureBusinessLogicEntityFramework.ConvertToDomain(p)).ToList();
            }

            return obj;
        }
    }
}
