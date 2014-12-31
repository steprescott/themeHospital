using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Domain.Wards
{
    public class WardWaitingList
    {
        public Guid WardWaitingListId { get; set; }
        public Ward Ward { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
