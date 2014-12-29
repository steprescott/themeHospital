using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class TreatmentBusinessLogicEntityFramework : ITreatmentBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Treatments.Operation> GetAllOperations()
        {
            var operations = _unitOfWork.GetAll<Operation>().ToList().OrderBy(o => o.Name);
            return operations.Select(ReflectiveMapperService.ConvertItem<Operation, Domain.Treatments.Operation>).ToList();
        }

        public Domain.Treatments.Operation GetOperationById(Guid id)
        {
            Operation operation = _unitOfWork.GetById<Operation>(id);
            return ReflectiveMapperService.ConvertItem<Operation, Domain.Treatments.Operation>(operation);
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
