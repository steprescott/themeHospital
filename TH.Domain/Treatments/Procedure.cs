using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class Procedure : Treatment
    {
        [DisplayName(@"Date administered")]
        public DateTime? DateAdministered { get; set; }

        [DisplayName(@"Operation ID")]
        public Guid OperationId { get; set; }

        public Operation Operation { get; set; }
    }
}
