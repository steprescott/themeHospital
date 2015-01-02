using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class Patient : User
    {
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }

        public List<Visit> Visits { get; set; }
        public List<Note> Notes { get; set; }
    }
}
