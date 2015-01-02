using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.UnitOfWorkEntityFramework
{
    public partial class Ward
    {
        public List<Bed> AvailableBeds
        {
            get
            {
                return Beds.SelectMany(b => b.Visits).Where(v => v.ReleaseDate == null)
                    .Select(v => v.Bed).ToList();
            }
        }
    }
}
