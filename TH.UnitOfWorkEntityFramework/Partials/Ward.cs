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
                var bedsWithoutVisits = Beds.AsEnumerable().Where(b => b.Visits == null || !b.Visits.Any());
                var bedsWithNoReleaseDate = Beds.Except(bedsWithoutVisits).AsEnumerable().Where(b => b.Visits.FirstOrDefault(v => v.ReleaseDate == null) == null);
                return bedsWithoutVisits.Concat(bedsWithNoReleaseDate).ToList();
            }
        }
    }
}
