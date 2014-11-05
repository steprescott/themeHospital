using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IPatientBusinessLogic
    {
        IEnumerable<Patient> GetAllUsers(); 
    }
}
