using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.User;

namespace TH.Domain.Wards
{
    public class WardWaitlingList
    {
        public System.Guid WardWaitingListId { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<Patient> Patients { get; set; } 

        public WardWaitlingList()
        {
            this.Patients = new HashSet<Patient>();
        }
    }
}
