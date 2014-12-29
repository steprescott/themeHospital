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

        public List<Domain.Treatment.Operation> GetAllOperations()
        {
            var operations = _unitOfWork.GetAll<Operation>().ToList().OrderBy(o => o.Name);
            return operations.Select(ReflectiveMapperService.ConvertItem<Operation, Domain.Treatment.Operation>).ToList();
        }

        public Domain.Treatment.Operation GetOperationById(Guid id)
        {
            Operation operation = _unitOfWork.GetById<Operation>(id);
            return ReflectiveMapperService.ConvertItem<Operation, Domain.Treatment.Operation>(operation);
        }


        public bool InsertProcedure(Domain.Treatment.Procedure procedure)
        {
            try
            {
                Procedure efProcedure = ReflectiveMapperService.ConvertItem<Domain.Treatment.Procedure, Procedure>(procedure);
                _unitOfWork.Insert(efProcedure);
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
