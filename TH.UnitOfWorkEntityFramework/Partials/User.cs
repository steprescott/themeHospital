using System;
using System.Collections.Generic;
using System.Linq;

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
