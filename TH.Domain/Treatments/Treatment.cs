using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Domain.Treatments
{
    public class Treatment
    {
        [DisplayName(@"Treatment ID")]
        public Guid TreatmentId { get; set; }

        [DisplayName(@"Scheduled date")]
        public DateTime ScheduledDate { get; set; }

        [DisplayName(@"Recorded by user ID")]
        public Guid RecordedByUserId { get; set; }

        [DisplayName(@"Assigned to user ID")]
        public Guid AssignedToUserId { get; set; }

        [DisplayName(@"Administered by user ID")]
        public Guid? AdministeredByUserId { get; set; }

        [DisplayName(@"Visit ID")]
        public Guid VisitId { get; set; }

        public StaffMember AdministeredBy { get; set; }

        public StaffMember AssignedTo { get; set; }

        public List<Note> Notes { get; set; }

        public Visit Visit { get; set; }

        public Refusal Refusal { get; set; }

        public Treatment()
        {
            Notes = new List<Note>();
        }
    }
}
