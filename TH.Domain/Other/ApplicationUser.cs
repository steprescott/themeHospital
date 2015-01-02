using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Enums;

namespace TH.Domain.Other
{
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public StaffType StaffType { get; set; }
    }
}
