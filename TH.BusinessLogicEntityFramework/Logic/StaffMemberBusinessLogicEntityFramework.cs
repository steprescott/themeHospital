using System;
using System.Collections.Generic;
using System.Linq;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using Consultant = TH.Domain.User.Consultant;
using Doctor = TH.Domain.User.Doctor;
using Receptionist = TH.Domain.User.Receptionist;
using StaffMember = TH.Domain.User.StaffMember;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class StaffMemberBusinessLogicEntityFramework : IStaffMemberBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffMemberBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateConsultant(Consultant domainConsultant)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainConsultant);

            //Make the staff member into its appropriate type
            var consultant = ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.StaffMember, UnitOfWorkEntityFramework.Consultant>(staffMember);

            //Set up specific parts of the consultant
            consultant.Skills = domainConsultant.Skills.Select(s => new Skill
            {
                SkillId = Guid.NewGuid(),
                Name = s.Name
            }).ToList();

            if (consultant.Team == null)
            {
                consultant.Team = new Team
                {
                    TeamId = Guid.NewGuid()
                };
            }
            
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

        public StaffMember GetStaffMemberWithId(Guid userId)
        {
            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.StaffMember, StaffMember>(_unitOfWork.GetById<UnitOfWorkEntityFramework.StaffMember>(userId));
        }

        public bool CreateOrUpdateDoctor(Doctor domainDoctor)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainDoctor);

            //Make the staff member into its appropriate type
            var doctor = ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.StaffMember, UnitOfWorkEntityFramework.Doctor>(staffMember);

            //Set up specific parts of the consultant
            if (doctor.Team != null)
            {
                doctor.Team.TeamId = doctor.Team.TeamId;
            }

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

        public bool CreateOrUpdateReceptionist(Receptionist domainReceptionist)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainReceptionist);

            //Make the staff member into its appropriate type
            var receptionist = ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.StaffMember, UnitOfWorkEntityFramework.Receptionist>(staffMember);

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

        private UnitOfWorkEntityFramework.StaffMember CreateOrUpdateStaffMemberObject(StaffMember domainStaffMember)
        {
            var staffMember = _unitOfWork.GetById<UnitOfWorkEntityFramework.StaffMember>(domainStaffMember.UserId);

            if (staffMember == null)
            {
                staffMember = new UnitOfWorkEntityFramework.StaffMember
                {
                    UserId = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    Username = domainStaffMember.Username,
                    Password = BasicEncryptDecryptUtilities.Encrypt(domainStaffMember.Password),
                    LastLoggedIn = domainStaffMember.LastLoggedIn
                };
            }

            staffMember.FirstName = domainStaffMember.FirstName;
            staffMember.OtherNames = domainStaffMember.OtherNames;
            staffMember.LastName = domainStaffMember.LastName;
            staffMember.DateOfBirth = domainStaffMember.DateOfBirth;
            staffMember.ContactNumber = domainStaffMember.ContactNumber;
            staffMember.Gender = domainStaffMember.Gender;

            return staffMember;
        }

        public bool DeleteStaffMember(StaffMember domainStaffMember)
        {
            return DeleteStaffMemberWithId(domainStaffMember.UserId);
        }
        
        public bool DeleteStaffMemberWithId(Guid userId)
        {
            try
            {
                var staffMember = _unitOfWork.GetById<UnitOfWorkEntityFramework.StaffMember>(userId);

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
            return _unitOfWork.GetAll<UnitOfWorkEntityFramework.StaffMember>().Any(s => s.UserId == userId);
        }
    }
}
