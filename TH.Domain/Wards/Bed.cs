using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Other
{
    public class Bed
    {
        [DisplayName(@"Bed ID")]
        public Guid BedId { get; set; }

        [DisplayName("Bed number")]
        public int Number { get; set; }

        [DisplayName(@"Ward ID")]
        public Guid WardId { get; set; }
    }
}
