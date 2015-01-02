using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.Wards
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
