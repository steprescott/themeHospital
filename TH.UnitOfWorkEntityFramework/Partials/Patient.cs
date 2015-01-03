using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.UnitOfWorkEntityFramework
{
    public partial class Patient
    {
        public Visit CurrentVisit
        {
            get
            {
                var currentVisit = this.Visits.SingleOrDefault(v => v.ReleaseDate == null);
                return currentVisit;
            }
        }
    }
}
