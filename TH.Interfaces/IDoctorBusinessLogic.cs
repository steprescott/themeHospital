using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IDoctorBusinessLogic
    {
        List<Doctor> GetAvailableDoctorsForConsultantsTeam(Guid userId);
    }
}
