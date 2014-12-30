using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Other
{
    public class Ward
    {
        public Guid WardId { get; set; }
        public int Number { get; set; }
        public List<Bed> Beds { get; set; }

        public Ward()
        {
            Beds = new List<Bed>();
        }
    }
}
