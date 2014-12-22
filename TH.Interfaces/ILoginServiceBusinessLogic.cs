using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface ILoginServiceBusinessLogic
    {
        bool ValidateStaffMember(string username, string password);
        ApplicationUser LoginStaffMember(string username, string password);
        bool ChangePassword(string username, string oldPassword, string newNassword);
    }
}
