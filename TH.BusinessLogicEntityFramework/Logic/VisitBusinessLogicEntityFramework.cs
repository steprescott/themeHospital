using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class VisitBusinessLogicEntityFramework : IVisitBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Other.Visit GetVisitWithId(Guid visitId)
        {
            var visit = _unitOfWork.GetById<Visit>(visitId);

            return ConvertToDomain(visit);
        }

        public List<Domain.User.StaffMember> MedicalStaffForVisitByVisitId(Guid visitId)
        {
            var visit = _unitOfWork.GetById<Visit>(visitId);

            if (visit != null)
            {
                List<StaffMember> doctors = visit.Teams.SelectMany(t => t.Doctors).Select(d => d as StaffMember).ToList();
                List<StaffMember> consultants = visit.Teams.Select(t => t.Consultant).Select(c => c as StaffMember).ToList();

                return doctors.Concat(consultants).Select(ms => StaffMemberBusinessLogicEntityFramework.ConvertToDomain(ms)).ToList();
            }
            return new List<Domain.User.StaffMember>();
        }

        public Domain.Other.Visit GetCurrentVisitForPatientId(Guid patientId)
        {
            var patient = _unitOfWork.GetById<Patient>(patientId);

            if (patient != null)
            {
                var visit = patient.Visits.SingleOrDefault(v => v.ReleaseDate == null);

                if (visit != null)
                {
                    return ConvertToDomain(visit);
                }
            }
            return null;
        }

        public Visit ConvertToEntityFramework(Domain.Other.Visit visit)
        {
            return new Visit
            {
                VisitId = visit.VisitId,
                AdmittedDate = visit.AdmittedDate,
                ReleaseDate = visit.ReleaseDate,
                BedId = visit.Bed.BedId,
                PatientUserId = visit.Patient.UserId
            };
        }

        public Domain.Other.Visit ConvertToDomain(Visit visit)
        {
            return new Domain.Other.Visit
            {
                VisitId = visit.VisitId,
                AdmittedDate = visit.AdmittedDate,
                ReleaseDate = visit.ReleaseDate,

                //NEEDS WORK
                //Bed = visit.Bed,
                Patient = PatientBusinessLogicEntityFramework.ConvertToDomain(visit.Patient)
            };
        }
    }
}
