using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IStaffMemberBusinessLogic
    {
        bool CreateOrUpdateConsultant(Consultant domainConsultant);
        bool CreateOrUpdateDoctor(Doctor domainConsultant);
        bool CreateOrUpdateReceptionist(Receptionist domainReceptionist);

        StaffMember GetStaffMemberWithId(Guid userId);

        bool DeleteStaffMemberWithId(Guid userId);
        bool DeleteStaffMember(StaffMember domainStaffMember);
    }
}
