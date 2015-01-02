using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;
using TH.Domain.Treatments;

namespace TH.Domain.Other
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public String Content { get; set; }
        public DateTime DateCreated { get; set; }
        public Patient Patient { get; set; }
        public Treatment Treatment { get; set; }
        public Visit Visit { get; set; }
        public Guid? PatientUserId { get; set; }
        public Guid? TreatmentId { get; set; }
        public Guid? VisitId { get; set; }
    }
}
