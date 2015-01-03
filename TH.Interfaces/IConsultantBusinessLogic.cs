using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IConsultantBusinessLogic
    {
        Consultant GetConsultantForDoctorId(Guid doctorId);
        Team GetTeamForConsultantId(Guid consultantId);
        bool AddDoctorToConsultantTeam(Guid consultantId, Guid doctorId);
        bool RemoveDoctorFromConsultantTeam(Guid consultantId, Guid doctorId);
    }
}
