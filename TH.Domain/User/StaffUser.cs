using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.User
{
    public class StaffUser
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }
    }
}
