using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Interfaces
{
    public interface IDoctorBusinessLogic
    {
        List<Domain.User.Doctor> GetAvailableDoctors();
    }
}
