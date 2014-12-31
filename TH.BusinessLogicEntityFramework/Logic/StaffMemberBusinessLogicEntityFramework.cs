using System;
using System.Collections.Generic;
using System.Linq;
using TH.BusinessLogicEntityFramework.Utilities;
using TH.EncryptionUtilities;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class StaffMemberBusinessLogicEntityFramework : IStaffMemberBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffMemberBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateConsultant(Domain.User.Consultant domainConsultant)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainConsultant);

            //Make the staff member into its appropriate type
            var consultant = StaffUtilities.ConvertStaffMemberToConsultant(staffMember);

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

        public Domain.User.StaffMember GetStaffMemberWithId(Guid userId)
        {
            var staffMember = _unitOfWork.GetById<StaffMember>(userId);

            return ConvertToDomain(staffMember);
        }

        public bool CreateOrUpdateDoctor(Domain.User.Doctor domainDoctor)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainDoctor);

            //Make the staff member into its appropriate type
            var doctor = StaffUtilities.ConvertStaffMemberToDoctor(staffMember);

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

        public bool CreateOrUpdateReceptionist(Domain.User.Receptionist domainReceptionist)
        {
            //Create or update the initial the base of staff member
            var staffMember = CreateOrUpdateStaffMemberObject(domainReceptionist);

            //Make the staff member into its appropriate type
            var receptionist = StaffUtilities.ConvertStaffMemberToReceptionist(staffMember);

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
            catch (Exception exception)
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

            staffMember.FirstName = domainStaffMember.FirstName;
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
            catch (Exception exception)
            {
                return false;
            }
        }

        public StaffMember ConvertToEntityFramework(Domain.User.StaffMember staffMember, bool solvedNested = false)
        {
            var obj = new StaffMember
            {
                UserId = staffMember.UserId,
                FirstName = staffMember.FirstName,
                LastName = staffMember.LastName,
                OtherNames = staffMember.OtherNames,
                DateCreated = staffMember.DateCreated,
                DateOfBirth = staffMember.DateOfBirth,
                ContactNumber = staffMember.ContactNumber,
                Gender = staffMember.Gender,
                Username = staffMember.Username,
                LastLoggedIn = staffMember.LastLoggedIn
            };

            if (solvedNested)
            {
                //TODO : This
                //obj.Treatments = ConsultantBusinessLogicEntityFramework.ConvertToEntityFramework(staffMember.Treatments);
                //obj.TreatmentsAssigned = ConsultantBusinessLogicEntityFramework.ConvertToEntityFramework(staffMember.TreatmentsAssigned);
            }

            return obj;
        }

        public static Domain.User.StaffMember ConvertToDomain(StaffMember staffMember, bool solvedNested = false)
        {
            var obj = new StaffMember
            {
                UserId = staffMember.UserId,
                FirstName = staffMember.FirstName,
                LastName = staffMember.LastName,
                OtherNames = staffMember.OtherNames,
                DateCreated = staffMember.DateCreated,
                DateOfBirth = staffMember.DateOfBirth,
                ContactNumber = staffMember.ContactNumber,
                Gender = staffMember.Gender,
                Username = staffMember.Username,
                LastLoggedIn = staffMember.LastLoggedIn
            };

            if (solvedNested)
            {
                //TODO : This
                //obj.Treatments = ConsultantBusinessLogicEntityFramework.ConvertToDomain(staffMember.Treatments);
                //obj.TreatmentsAssigned = ConsultantBusinessLogicEntityFramework.ConvertToDomain(staffMember.TreatmentsAssigned);
            }

            return obj;
        }

        private bool StaffMemberExists(Guid userId)
        {
            return _unitOfWork.GetAll<StaffMember>().Any(s => s.UserId == userId);
        }
    }
}
