using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface IVisitBusinessLogic
    {
        Visit GetVisitWithId(Guid id);

        List<Domain.User.StaffMember> MedicalStaffForVisitWithId(Guid id);
        List<Domain.User.Consultant> ConsultantsForVisitWithId(Guid id);
    }
}
