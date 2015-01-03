using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.Wards
{
    public class Bed
    {
        [DisplayName(@"Bed ID")]
        public Guid BedId { get; set; }

        [DisplayName("Bed number")]
        public int Number { get; set; }

        [DisplayName(@"Ward ID")]
        public Guid WardId { get; set; }

        [DisplayName("Visits")]
        public List<Visit> Visits { get; set; }
        
        [DisplayName("Is available")]
        public bool IsAvailable
        {
            get
            {
                if(Visits != null && Visits.Any())
                {
                    return Visits.All(v => v.ReleaseDate.HasValue);
                }

                return true;
            }
        }
    }
}
