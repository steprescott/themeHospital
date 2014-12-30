using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Domain.Treatments
{
    public class Treatment
    {
        public Guid TreatmentId { get; set; }

        public DateTime ScheduledDate { get; set; }

        public List<Note> Notes { get; set; }
    }
}
