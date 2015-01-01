using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class Medicine
    {
        public Guid MedicineId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
