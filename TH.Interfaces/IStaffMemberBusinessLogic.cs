using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IStaffMemberBusinessLogic
    {
        bool InsertOrUpdateConsultant(Consultant domainConsultant);
        bool InsertOrUpdateDoctor(Doctor domainConsultant);
        bool InsertOrUpdateReceptionist(Receptionist domainReceptionist);

        bool DeleteStaffMemberWithId(Guid userId);
        bool DeleteStaffMember(StaffMember domainStaffMember);
    }
}
