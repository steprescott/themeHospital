using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.UnitOfWorkEntityFramework
{
    public partial class Ward
    {
        public List<Bed> AvailableBeds
        {
            get
            {
                var takenBeds = Beds.SelectMany(b => b.Visits).Where(v => v.ReleaseDate != null).Select(v => v.Bed).ToList();
                return Beds.Except(takenBeds).ToList();
            }
        }
    }
}
