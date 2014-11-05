using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain;

namespace TH.Interfaces
{
    public interface IUserBusinessLogic
    {
        IEnumerable<User> GetAllUsers(); 
    }
}
