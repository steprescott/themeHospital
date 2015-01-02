using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Other
{
    public class Bed
    {
        public Guid BedId { get; set; }

        [DisplayName("Bed number")]
        public int Number { get; set; }
        public Guid WardId { get; set; }
    }
}
