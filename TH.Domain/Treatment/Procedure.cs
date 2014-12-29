using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Domain.Treatment
{
    public class Procedure : Treatment
    {
        public DateTime DateAdministered { get; set; }
        public Domain.Treatment.Operation Operation { get; set; }
    }
}
