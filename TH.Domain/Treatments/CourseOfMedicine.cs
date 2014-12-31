using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TH.Domain.Treatments
{
    public class CourseOfMedicine : Treatment
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Instructions { get; set; }
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
