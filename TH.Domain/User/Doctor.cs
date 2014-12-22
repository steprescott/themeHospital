using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class Doctor : StaffMember
    {
        public Team Team { get; set; }
    }
}
