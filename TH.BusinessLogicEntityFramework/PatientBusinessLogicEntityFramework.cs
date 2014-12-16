using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TH.BusinessLogicEntityFramework.Resolvers;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework
{
    public class PatientBusinessLogicEntityFramework : IPatientBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            Mapper.CreateMap<Patient, Domain.User.Patient>()
                .ForMember(dest => dest.Addresses, opt => opt.ResolveUsing<DomainAddressResolver>().FromMember(src => src.Addresses));

            Mapper.CreateMap<Domain.User.Patient, Patient>()
                .ForMember(dest => dest.Addresses, opt => opt.ResolveUsing<EntityFrameworkAddressResolver>().FromMember(src => src.Addresses));
        }

        public IEnumerable<Domain.User.Patient> GetAllPatients()
        {
            var patients = _unitOfWork.GetAll<Patient>().ToList();

            return patients.Select(p => Mapper.Map<Domain.User.Patient>(p));
        }

        public Domain.User.Patient GetPatientWithId(Guid userId)
        {
            return Mapper.Map<Domain.User.Patient>(_unitOfWork.GetById<Patient>(userId));
        }

        public bool InsertOrUpdatePatient(Domain.User.Patient domainPatient)
        {
            var patient = _unitOfWork.GetById<Patient>(domainPatient.UserId);

            if (patient == null)
            {
                domainPatient.UserId = domainPatient.UserId == null ? Guid.NewGuid() : domainPatient.UserId;
                domainPatient.DateCreated = DateTime.Now;
            }

            try
            {
                patient = Mapper.Map<Patient>(domainPatient);

                _unitOfWork.Insert(patient);
                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool DeletePatient(Domain.User.Patient domainPatient)
        {
            return DeletePatientWithId(domainPatient.UserId);
        }
        
        public bool DeletePatientWithId(Guid userId)
        {
            try
            {
                Patient patient = _unitOfWork.GetById<Patient>(userId);

                if (patient != null)
                {
                    _unitOfWork.Delete(patient);
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
