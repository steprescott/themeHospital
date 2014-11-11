using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework
{
    public class LoginServiceBusinessLogicEntityFramework : ILoginServiceBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginServiceBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ValidateUser(string username, string password)
        {
            return _unitOfWork.GetAll<StaffMemeber>().Any(sm =>
                sm.Username == username && password == BasicEncryptDecryptUtilities.Encrypt(password));
        }

        public StaffUser LoginUser(string username, string password)
        {
            var user = _unitOfWork.GetAll<StaffMemeber>().SingleOrDefault(sm =>
                sm.Username == username && password == BasicEncryptDecryptUtilities.Encrypt(password));
            
            return user == null ? null : new StaffUser
            {
                UserId = user.UserId,
                Firstname = user.FirstName,
                Surname = user.LastName,
                Username = user.Username
            };
        }

        public bool ChangePassword(string username, string oldPassword, string newNassword)
        {
            if (ValidateUser(username, oldPassword))
            {
                var user = _unitOfWork.GetAll<StaffMemeber>().Single(sm =>
                    sm.Username == username && oldPassword == BasicEncryptDecryptUtilities.Encrypt(oldPassword));

                user.Password = BasicEncryptDecryptUtilities.Encrypt(newNassword);
                _unitOfWork.Update(user);

                return true;
            }
            return false;
        }
    }
}
