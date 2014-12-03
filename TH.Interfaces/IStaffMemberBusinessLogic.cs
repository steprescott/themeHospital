using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IStaffMemberBusinessLogic
    {
        bool ValidateStaffMember(string username, string password);
        StaffMember LoginStaffMember(string username, string password);
        bool ChangePassword(string username, string oldPassword, string newNassword);

        bool InsertOrUpdateStaffMember(Domain.User.StaffMember domainStaffMember);
        bool DeleteStaffMemberWithId(Guid userId);
        bool DeleteStaffMember(Domain.User.StaffMember domainStaffMember);
    }
}
