using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.Domain.Other
{
    public class Visit
    {
        [DisplayName(@"Visit ID")]
        public Guid VisitId { get; set; }

        [DisplayName(@"Admitted date")]
        public DateTime AdmittedDate { get; set; }

        [DisplayName(@"Release date")]
        public DateTime? ReleaseDate { get; set; }

        public Patient Patient { get; set; }
        public List<Team> Teams { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Note> Notes { get; set; }
        public Bed Bed { get; set; }

        public Visit()
        {
            Teams = new List<Team>();
            Treatments = new List<Treatment>();
            Notes = new List<Note>();
        }
    }
}
