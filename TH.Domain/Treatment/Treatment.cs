using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Domain.Treatment
{
    public class Treatment
    {
        public Guid TreatmentId { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
