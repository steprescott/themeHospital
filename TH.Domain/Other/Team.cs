using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.User;

namespace TH.Domain.Other
{
    public class Team
    {
        [DisplayName(@"Team ID")]
        public Guid TeamId { get; set; }

        public Consultant Consultant { get; set; }

        public HashSet<Doctor> Doctors { get; set; }

        public Team()
        {
            Doctors = new HashSet<Doctor>();
        }
    }
}
