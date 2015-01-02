using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Treatments
{
    public class CourseOfMedicine : Treatment
    {
        public DateTime EndDate { get; set; }

        public String Instructions { get; set; }

        public Medicine Medicine { get; set; }

        public Guid MedicineId { get; set; }
    }
}
