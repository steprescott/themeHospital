using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Interfaces
{
    public interface ITeamBusinessLogic
    {
        Domain.Other.Team GetTeamForDoctorId(Guid doctorId);
        List<Domain.User.Doctor> GetTeamMembersForConsultant(Guid consultantId);
    }
}
