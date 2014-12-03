using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.User
{
    public class Patient : User
    {
        public Patient()
        {

        }

        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
    }
}
