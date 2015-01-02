﻿using System;
using System.Collections.Generic;
using System.Linq;
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
