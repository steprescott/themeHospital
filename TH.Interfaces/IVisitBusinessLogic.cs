using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IVisitBusinessLogic
    {
        Visit GetVisitWithId(Guid id);
        List<StaffMember> GetMedicalStaffForVisitWithId(Guid visitId);
        List<Visit> GetAllPatientsWithOpenVisits();
        List<Visit> GetOpenVisitsForDoctorId(Guid userId);
        List<Visit>  GetOpenVisitsForConsultantId(Guid consultantId);

    }
}
