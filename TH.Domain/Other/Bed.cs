using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Wards;

namespace TH.Domain.Other
{
    public class Bed
    {
        public Guid BedId { get; set; }
        public int Number { get; set; }
        public Ward Ward { get; set; }
        public List<Visit> Visits { get; set; }

        public Bed()
        {
            Visits = new List<Visit>();
        }
    }
}
