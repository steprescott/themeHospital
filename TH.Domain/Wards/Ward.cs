using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Wards
{
    public class Ward
    {
        [DisplayName(@"Ward ID")]
        public Guid WardId { get; set; }

        [DisplayName(@"Ward number")]
        public int Number { get; set; }

        public List<Bed> Beds { get; set; }

        public List<Bed> AvailableBeds { get; set; }

        public WardWaitingList WardWaitingList { get; set; }
        public Ward()
        {
            Beds = new List<Bed>();
        }
    }
}
