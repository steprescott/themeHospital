using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Other
{
    public class Bed
    {
        public Guid BedId { get; set; }
        public int Number { get; set; }
        public Guid WardId { get; set; }
    }
}
