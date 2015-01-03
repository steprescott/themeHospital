using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface ITeamBusinessLogic
    {
        Team GetTeamForDoctorId(Guid doctorId);
        List<Doctor> GetTeamMembersForConsultant(Guid consultantId);
        List<Team> GetAll();
    }
}
