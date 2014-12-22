﻿using System;
using System.Collections.Generic;
using System.Linq;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.ReflectiveMapper;
using Consultant = TH.UnitOfWorkEntityFramework.Consultant;
using Doctor = TH.UnitOfWorkEntityFramework.Doctor;
using Receptionist = TH.UnitOfWorkEntityFramework.Receptionist;
using Skill = TH.UnitOfWorkEntityFramework.Skill;
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

        public bool InsertOrUpdateConsultant(Domain.User.Consultant domainConsultant)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainConsultant);

            //Make the staff member into its appropriate type
            var consultant = ReflectiveMapperService.ConvertItem<StaffMember, Consultant>(staffMember);

            //Set up specific parts of the consultant
            consultant.Skills = domainConsultant.Skills.Select(s => new Skill
            {
                SkillId = Guid.NewGuid(),
                Name = s.Name
            }).ToList();

            consultant.Team.TeamId = domainConsultant.Team.TeamId;
            
            //Attempt to create or update the staff member
            try
            {
                if (!StaffMemberExists(consultant.UserId))
                {
                    _unitOfWork.Insert(consultant);
                }
                else
                {
                    _unitOfWork.Update(consultant);
                }

                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertOrUpdateDoctor(Domain.User.Doctor domainDoctor)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainDoctor);

            //Make the staff member into its appropriate type
            var doctor = ReflectiveMapperService.ConvertItem<StaffMember, Doctor>(staffMember);

            //Set up specific parts of the consultant
            doctor.Team.TeamId = doctor.Team.TeamId;

            //Attempt to create or update the staff member
            try
            {
                if (!StaffMemberExists(doctor.UserId))
                {
                    _unitOfWork.Insert(doctor);
                }
                else
                {
                    _unitOfWork.Update(doctor);
                }

                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertOrUpdateReceptionist(Domain.User.Receptionist domainReceptionist)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainReceptionist);

            //Make the staff member into its appropriate type
            var receptionist = ReflectiveMapperService.ConvertItem<StaffMember, Receptionist>(staffMember);

            //Attempt to create or update the staff member
            try
            {
                if (!StaffMemberExists(receptionist.UserId))
                {
                    _unitOfWork.Insert(receptionist);
                }
                else
                {
                    _unitOfWork.Update(receptionist);
                }

                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private StaffMember CreateOrUpdateStaffMemberObject(Domain.User.StaffMember domainStaffMember)
        {
            var staffMember = _unitOfWork.GetById<StaffMember>(domainStaffMember.UserId);

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

            return staffMember;
        }

        public bool DeleteStaffMember(Domain.User.StaffMember domainStaffMember)
        {
            return DeleteStaffMemberWithId(domainStaffMember.UserId);
        }
        
        public bool DeleteStaffMemberWithId(Guid userId)
        {
            try
            {
                var staffMember = _unitOfWork.GetById<StaffMember>(userId);

                if (staffMember != null)
                {
                    _unitOfWork.Delete(staffMember);
                    _unitOfWork.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool StaffMemberExists(Guid userId)
        {
            return _unitOfWork.GetAll<StaffMember>().Any(s => s.UserId == userId);
        }
    }
}
