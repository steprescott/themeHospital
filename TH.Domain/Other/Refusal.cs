﻿using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Domain.Other
{
    public class Refusal
    {
        public Guid RefusalId { get; set; }
        public Note Note { get; set; }
        public Treatment Treatment { get; set; }
    }
}
