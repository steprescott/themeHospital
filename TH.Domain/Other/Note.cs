using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.User;
using TH.Domain.Treatments;

namespace TH.Domain.Other
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public String Content { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? TreatmentId { get; set; }
        public Guid? VisitId { get; set; }
    }
}
