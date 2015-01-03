using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Domain.Wards
{
    public class WardWaitingList
    {
        public Guid WardWaitingListId { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<Patient> Patients { get; set; } 

        public WardWaitingList()
        {
            Patients = new HashSet<Patient>();
        }
    }
}
