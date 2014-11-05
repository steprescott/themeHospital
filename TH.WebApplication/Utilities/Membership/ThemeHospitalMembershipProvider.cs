using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TH.Container;
using TH.Domain;
using TH.Domain.Enums;
using TH.Domain.User;
using TH.Interfaces;

namespace TH.WebApplication.Utilities.Membership
{
    public class ThemeHospitalMembershipProvider : MembershipProvider
    {
        static readonly ILoginServiceBusinessLogic loginService = ThemeHospitalContainer.GetInstance<ILoginServiceBusinessLogic>();

        private static StaffUser User
        {
            get { return (StaffUser)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        public StaffUser GetUser()
        {
            return User;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (User != null)
            {
                return new ThemeHospitalMembershipUser("ThemeHospitalMembershipUser", User);
            }

            //LogCurrentUserOut();
            return null;
        }

        public static LoginResult LogUserIn(string username, string password)
        {
            User = loginService.LoginUser(username, password);

            if (User != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return LoginResult.Success;
            }

            return LoginResult.Invalid;
        }

        public static void LogCurrentUserOut()
        {
            var session = HttpContext.Current.Session;
            session.Clear();
            session.Abandon();

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public override bool ValidateUser(string username, string password)
        {
            return loginService.ValidateUser(username, password);
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return loginService.ChangePassword(username, oldPassword, newPassword);
        }

        //Used functions
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
                                                  bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
    }
}