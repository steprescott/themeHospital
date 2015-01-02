using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class Patient : User
    {
        [DisplayName("Emergency contact name")]
        public string EmergencyContactName { get; set; }

        [DisplayName("Emergency contact number")]
        public string EmergencyContactNumber { get; set; }

        public List<Visit> Visits { get; set; }
        public List<Note> Notes { get; set; }
    }
}
