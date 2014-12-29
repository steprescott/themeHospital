using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface IOperationBusinessLogic
    {
        bool CreateOrUpdateOperation(Operation operation);

        bool DeleteOperationWithId(Guid operationId);

        List<Operation> GetAllOperations();

        Operation GetOperationById(Guid id);
    }
}
