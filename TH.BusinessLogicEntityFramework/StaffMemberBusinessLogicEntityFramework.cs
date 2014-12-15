using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.User;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;
using Patient = TH.UnitOfWorkEntityFramework.Patient;
using StaffMember = TH.UnitOfWorkEntityFramework.StaffMember;

namespace TH.BusinessLogicEntityFramework
{
    public class StaffMemberBusinessLogicEntityFramework : IStaffMemberBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffMemberBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ValidateStaffMember(string username, string password)
        {
            return _unitOfWork.GetAll<Domain.User.StaffMember>().Any(sm =>
                sm.Username == username && password == BasicEncryptDecryptUtilities.Encrypt(password));
        }

        public Domain.User.StaffMember LoginStaffMember(string username, string password)
        {
            var encryptedPassword = BasicEncryptDecryptUtilities.Encrypt(password);
            var user = _unitOfWork.GetAll<StaffMember>().SingleOrDefault(sm =>
                sm.Username == username && sm.Password == encryptedPassword);
            
            return user == null ? null : new Domain.User.StaffMember
            {
                UserId = user.UserId,
                Firstname = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
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

        public bool InsertOrUpdateStaffMember(Domain.User.StaffMember domainStaffMember)
        {
            StaffMember staffMember = _unitOfWork.GetById<StaffMember>(domainStaffMember.UserId);

            if (staffMember == null)
            {
                staffMember = new StaffMember
                {
                    UserId = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    Username = domainStaffMember.Username,
                    Password = BasicEncryptDecryptUtilities.Encrypt(domainStaffMember.Password),
                    LastLoggedIn = domainStaffMember.LastLoggedIn
                };
            }

            staffMember.FirstName = domainStaffMember.Firstname;
            staffMember.OtherNames = domainStaffMember.OtherNames;
            staffMember.LastName = domainStaffMember.LastName;
            staffMember.DateOfBirth = domainStaffMember.DateOfBirth;
            staffMember.ContactNumber = domainStaffMember.ContactNumber;
            staffMember.Gender = domainStaffMember.Gender;

            try
            {
                _unitOfWork.Insert(staffMember);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteStaffMember(Domain.User.StaffMember domainStaffMember)
        {
            return DeleteStaffMemberWithId(domainStaffMember.UserId);
        }
        
        public bool DeleteStaffMemberWithId(Guid userId)
        {
            try
            {
                StaffMember staffMember = _unitOfWork.GetById<StaffMember>(userId);

                if (staffMember != null)
                {
                    _unitOfWork.Delete(staffMember);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
