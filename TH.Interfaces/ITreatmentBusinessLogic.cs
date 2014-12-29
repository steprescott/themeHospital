using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Treatment;

namespace TH.Interfaces
{
    public interface ITreatmentBusinessLogic
    {
        List<Operation>GetAllOperations();

        Operation GetOperationById(Guid id);

        bool InsertProcedure(Domain.Treatment.Procedure procedure);
    }
}
