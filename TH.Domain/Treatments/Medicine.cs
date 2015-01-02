using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class Medicine
    {
        [DisplayName(@"Medicine ID")]
        public Guid MedicineId { get; set; }

        [DisplayName(@"Name")]
        public String Name { get; set; }

        [DisplayName(@"Description")]
        public String Description { get; set; }
    }
}
