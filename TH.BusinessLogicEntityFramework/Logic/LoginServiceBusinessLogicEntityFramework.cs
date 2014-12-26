using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Enums;
using TH.Domain.Other;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class LoginServiceBusinessLogicEntityFramework : ILoginServiceBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginServiceBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ValidateStaffMember(string username, string password)
        {
            return _unitOfWork.GetAll<Domain.User.StaffMember>().Any(sm =>
                sm.Username == username && password == BasicEncryptDecryptUtilities.Encrypt(password));
        }

        public ApplicationUser LoginStaffMember(string username, string password)
        {
            var encryptedPassword = BasicEncryptDecryptUtilities.Encrypt(password);
            var user = _unitOfWork.GetAll<StaffMember>().SingleOrDefault(sm => sm.Username == username &&
                sm.Password == encryptedPassword);

            return user == null ? null : new ApplicationUser
            {
                UserId = user.UserId,
                Firstname = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                StaffType = GetRoleForUserId(user.UserId)
            };
        }

        public bool ChangePassword(string username, string oldPassword, string newNassword)
        {
            if (ValidateStaffMember(username, oldPassword))
            {
                var user = _unitOfWork.GetAll<StaffMember>().Single(sm =>
                    sm.Username == username && oldPassword == BasicEncryptDecryptUtilities.Encrypt(oldPassword));

                user.Password = BasicEncryptDecryptUtilities.Encrypt(newNassword);
                _unitOfWork.Update(user);

                return true;
            }
            return false;
        }

        private StaffType GetRoleForUserId(Guid userId)
        {
            var consultant = _unitOfWork.GetInheritedSubTypeObjects<StaffMember, Consultant>()
                                        .SingleOrDefault(c => c.UserId == userId);

            if (consultant == null)
            {
                var doctor = _unitOfWork.GetInheritedSubTypeObjects<StaffMember, Doctor>()
                                        .SingleOrDefault(c => c.UserId == userId);

                if (doctor == null)
                {
                    return StaffType.Receptionist;
                }
                return StaffType.Doctor;
            }
            return StaffType.Consultant;
        }
    }
}
