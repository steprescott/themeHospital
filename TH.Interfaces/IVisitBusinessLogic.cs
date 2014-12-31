using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface IVisitBusinessLogic
    {
        Visit GetVisitWithId(Guid id);

        List<Domain.User.StaffMember> MedicalStaffForVisitWithId(Guid id);
    }
}
