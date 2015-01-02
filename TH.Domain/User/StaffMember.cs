using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.User
{
    public class StaffMember : User
    {
        [DisplayName(@"Username")]
        public string Username { get; set; }

        [DisplayName(@"Password")]
        public string Password { get; set; }

        [DisplayName(@"Last logged in")]
        public DateTime LastLoggedIn { get; set; }
    }
}
