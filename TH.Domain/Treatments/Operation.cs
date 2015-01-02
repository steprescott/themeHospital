using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class Operation
    {
        [DisplayName(@"Operation ID")]
        public Guid OperationId { get; set; }

        [DisplayName(@"Name")]
        public String Name { get; set; }

        [DisplayName(@"Description")]
        public String Description { get; set; }
    }
}
