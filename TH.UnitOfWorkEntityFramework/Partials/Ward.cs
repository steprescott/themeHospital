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
                var availableBeds = Beds.AsEnumerable();

                availableBeds = availableBeds.Where(b => !b.Visits.Any());

                availableBeds = availableBeds.Where(b => b.Visits.Select(v => v.ReleaseDate) != null);

                return availableBeds.ToList();
            }
        }
    }
}
