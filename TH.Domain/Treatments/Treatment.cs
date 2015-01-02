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

        public Guid RecordedByUserId { get; set; }

        public Guid AssignedToUserId { get; set; }

        public Guid? AdministeredByUserId { get; set; }

        public StaffMember AdministeredBy { get; set; }

        public List<Note> Notes { get; set; }

        public Guid VisitId { get; set; }

        public Visit Visit { get; set; }

        public Treatment()
        {
            Notes = new List<Note>();
        }
    }
}
