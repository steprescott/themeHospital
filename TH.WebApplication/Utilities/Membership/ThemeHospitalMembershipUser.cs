using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TH.Domain;
using TH.Domain.User;

namespace TH.WebApplication.Utilities.Membership
{
    public class ThemeHospitalMembershipUser : MembershipUser
    {
        private readonly StaffMember _member;

        public ThemeHospitalMembershipUser(string providerName,
            string name,
            object providerUserKey,
            string email,
            string passwordQuestion,
            string comment,
            bool isApproved,
            bool isLockedOut,
            DateTime creationDate,
            DateTime lastLoginDate,
            DateTime lastActivityDate,
            DateTime lastPasswordChangedDate,
            DateTime lastLockoutDate) :
            base(providerName, name, providerUserKey, email, passwordQuestion, comment, isApproved,
                isLockedOut, creationDate, lastLoginDate, lastActivityDate, lastPasswordChangedDate,
                lastLockoutDate)
        { }

        public ThemeHospitalMembershipUser(string providerName, StaffMember memberRoles) :
            this(providerName,
                 memberRoles.Username,
                 memberRoles.UserId,
                 null,
                 null,
                 null,
                 true,
                 false,
                 DateTime.MinValue,
                 DateTime.MinValue,
                 DateTime.MinValue,
                 DateTime.MinValue,
                 DateTime.MinValue)
        {
            _member = memberRoles;
        }
    }
}