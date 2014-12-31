using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Domain.Treatments
{
    public class Procedure : Treatment
    {
        public DateTime DateAdministered { get; set; }

        public Guid OperationId { get; set; }
    }
}
