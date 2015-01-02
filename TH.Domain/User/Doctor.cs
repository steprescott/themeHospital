using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.User
{
    public class Doctor : StaffMember
    {
        [DisplayName(@"Team ID")]
        public Guid TeamId { get; set; }
    }
}
