﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface IProcedureBusinessLogic
    {
        bool CreateProcedure(Procedure procedure);
    }
}
