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

            return ConvertToDomain(visit, true);
        }

        public List<Domain.User.StaffMember> MedicalStaffForVisitByVisitId(Guid visitId)
        {
            var visit = _unitOfWork.GetById<Visit>(visitId);

            if (visit != null)
            {
                List<StaffMember> doctors = visit.Teams.SelectMany(t => t.Doctors).Select(d => d as StaffMember).ToList();
                List<StaffMember> consultants = visit.Teams.Select(t => t.Consultant).Select(c => c as StaffMember).ToList();

                return doctors.Concat(consultants).Select(ms => StaffMemberBusinessLogicEntityFramework.ConvertToDomain(ms, true)).ToList();
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
                    return ConvertToDomain(visit, true);
                }
            }
            return null;
        }

        public static Visit ConvertToEntityFramework(Domain.Other.Visit visit, bool solvedNested = false)
        {
            var obj = new Visit
            {
                VisitId = visit.VisitId,
                AdmittedDate = visit.AdmittedDate,
                ReleaseDate = visit.ReleaseDate,
            };

            if (solvedNested)
            {
                obj.Patient = PatientBusinessLogicEntityFramework.ConvertToEntityFramework(visit.Patient);
                obj.Bed = BedBusinessLogicEntityFramework.ConvertToEntityFramework(visit.Bed);
                //TODO: THIS
                //obj.Treatments = visit.Treatments.Select(t => Trea)
                obj.Notes = visit.Notes.Select(n => NotesBusinessLogicEntityFramework.ConvertToEntityFramework(n)).ToList();
                obj.Teams = visit.Teams.Select(t => TeamBusinessLogicEntityFramework.ConvertToEntityFramework(t)).ToList();
            }

            return obj;
        }

        public static Domain.Other.Visit ConvertToDomain(Visit visit, bool solvedNested = false)
        {
            var obj = new Domain.Other.Visit
            {
                VisitId = visit.VisitId,
                AdmittedDate = visit.AdmittedDate,
                ReleaseDate = visit.ReleaseDate,
            };

            if (solvedNested)
            {
                obj.Patient = PatientBusinessLogicEntityFramework.ConvertToDomain(visit.Patient);
                obj.Bed = BedBusinessLogicEntityFramework.ConvertToDomain(visit.Bed);
                //TODO: THIS
                //obj.Treatments = visit.Treatments.Select(t => Trea)
                obj.Notes = visit.Notes.Select(n => NotesBusinessLogicEntityFramework.ConvertToDomain(n)).ToList();
                obj.Teams = visit.Teams.Select(t => TeamBusinessLogicEntityFramework.ConvertToDomain(t)).ToList();
            }

            return obj;
        }
    }
}
