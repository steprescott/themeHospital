using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.UnitOfWorkEntityFramework
{
    public partial class User
    {
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
