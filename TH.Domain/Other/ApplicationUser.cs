using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Enums;

namespace TH.Domain.Other
{
    public class ApplicationUser
    {
        [DisplayName(@"User ID")]
        public Guid UserId { get; set; }

        [DisplayName(@"First name")]
        public string FirstName { get; set; }

        [DisplayName(@"Last name")]
        public string LastName { get; set; }

        [DisplayName(@"Username")]
        public string Username { get; set; }

        [DisplayName(@"Staff type")]
        public StaffType StaffType { get; set; }
    }
}
