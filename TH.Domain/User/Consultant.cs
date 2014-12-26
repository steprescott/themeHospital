using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class Consultant : StaffMember
    {
        public Guid TeamId { get; set; }
        public IList<Skill> Skills { get; set; }

        public Consultant()
        {
            Skills = new List<Skill>();
        }
    }
}
