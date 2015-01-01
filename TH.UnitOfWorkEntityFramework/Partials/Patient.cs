using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.UnitOfWorkEntityFramework
{
    public partial class Patient
    {
        public Visit CurrentVisit
        {
            get
            {
                return this.Visits.SingleOrDefault(v => v.ReleaseDate == null);
            }
        }
    }
}
