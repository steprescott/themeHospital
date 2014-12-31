using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Utilities
{
    public static class StaffUtilities
    {
        public static Consultant ConvertStaffMemberToConsultant(StaffMember staffMember)
        {
            return new Consultant
            {
                UserId = staffMember.UserId,
                FirstName = staffMember.FirstName,
                LastName = staffMember.LastName,
                OtherNames = staffMember.OtherNames,
                DateCreated = staffMember.DateCreated,
                DateOfBirth = staffMember.DateOfBirth,
                ContactNumber = staffMember.ContactNumber,
                Gender = staffMember.Gender,
                Addresses = staffMember.Addresses.Select(a => new Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList(),
                Username = staffMember.Username,
                LastLoggedIn = staffMember.LastLoggedIn
            };
        }

        public static Doctor ConvertStaffMemberToDoctor(StaffMember staffMember)
        {
            return new Doctor
            {
                UserId = staffMember.UserId,
                FirstName = staffMember.FirstName,
                LastName = staffMember.LastName,
                OtherNames = staffMember.OtherNames,
                DateCreated = staffMember.DateCreated,
                DateOfBirth = staffMember.DateOfBirth,
                ContactNumber = staffMember.ContactNumber,
                Gender = staffMember.Gender,
                Addresses = staffMember.Addresses.Select(a => new Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList(),
                Username = staffMember.Username,
                LastLoggedIn = staffMember.LastLoggedIn
            };
        }

        public static Receptionist ConvertStaffMemberToReceptionist(StaffMember staffMember)
        {
            return new Receptionist
            {
                UserId = staffMember.UserId,
                FirstName = staffMember.FirstName,
                LastName = staffMember.LastName,
                OtherNames = staffMember.OtherNames,
                DateCreated = staffMember.DateCreated,
                DateOfBirth = staffMember.DateOfBirth,
                ContactNumber = staffMember.ContactNumber,
                Gender = staffMember.Gender,
                Addresses = staffMember.Addresses.Select(a => new Address
                {
                    AddressId = a.AddressId,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    City = a.City,
                    PostCode = a.PostCode,
                    IsCurrentAddress = a.IsCurrentAddress
                }).ToList(),
                Username = staffMember.Username,
                LastLoggedIn = staffMember.LastLoggedIn
            };
        }
    }
}
