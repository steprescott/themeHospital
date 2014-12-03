using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface ILoginServiceBusinessLogic
    {
        bool ValidateUser(string username, string password);
        StaffMember LoginUser(string username, string password);
        bool ChangePassword(string username, string oldPassword, string newNassword);
    }
}
