using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Other
{
    public class Skill
    {
        [DisplayName(@"Skill ID")]
        public Guid SkillId { get; set; }

        [DisplayName(@"Name")]
        public string Name { get; set; }
    }
}
