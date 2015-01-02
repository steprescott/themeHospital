using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class CourseOfMedicine : Treatment
    {
        [DisplayName(@"End date")]
        public DateTime EndDate { get; set; }

        [DisplayName(@"Instructions")]
        public String Instructions { get; set; }

        [DisplayName(@"Medicine ID")]
        public Guid MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}
