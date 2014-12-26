using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Interfaces
{
    public interface IConsultantBusinessLogic
    {
        Domain.User.Consultant GetConsultantForDoctorId(Guid doctorId);
        Domain.Other.Team GetTeamForConsultantId(Guid consultantId);
        bool AddDoctorToConsultantTeam(Guid consultantId, Guid doctorId);
        bool RemoveDoctorFromConsultantTeam(Guid consultantId, Guid doctorId);
    }
}
