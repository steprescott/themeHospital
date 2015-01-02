using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.User;
using TH.Domain.Treatments;

namespace TH.Domain.Other
{
    public class Note
    {
        [DisplayName(@"Note ID")]
        public Guid NoteId { get; set; }

        [DisplayName(@"Content")]
        public String Content { get; set; }

        [DisplayName(@"Date created")]
        public DateTime DateCreated { get; set; }

        [DisplayName(@"Patient ID")]
        public Guid? PatientUserId { get; set; }

        [DisplayName(@"Treatment ID")]
        public Guid? TreatmentId { get; set; }

        [DisplayName(@"Visit ID")]
        public Guid? VisitId { get; set; }

        public Patient Patient { get; set; }
        public Treatment Treatment { get; set; }
        public Visit Visit { get; set; }
    }
}
