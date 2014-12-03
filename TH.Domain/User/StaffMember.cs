using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.User
{
    public class StaffMember : User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime LastLoggedIn { get; set; }
    }
}
