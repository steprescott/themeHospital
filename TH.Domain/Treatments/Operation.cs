using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class Operation
    {
        public Guid OperationId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<Procedure> Procedures { get; set; } 
    }
}
