using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class CourseOfMedicineBusinessLogicEntityFramework : ICourseOfMedicine
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseOfMedicineBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateCauseOfMedicne(Domain.Treatments.CourseOfMedicine courseOfMedicine)
        {
            try
            {
                CourseOfMedicine efObject = ConvertToEntityFramework(courseOfMedicine, true);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static CourseOfMedicine ConvertToEntityFramework(Domain.Treatments.CourseOfMedicine courseOfMedicine, bool solvedNested = false)
        {
            var obj = new CourseOfMedicine
            {
                TreatmentId = courseOfMedicine.TreatmentId,
                MedicineId = courseOfMedicine.MedicineId,
                ScheduledDate = courseOfMedicine.ScheduledDate,
                VisitId = courseOfMedicine.VisitId,
                RecordedByUserId = courseOfMedicine.RecordedByUserId,
                AdministeredByUserId = courseOfMedicine.AdministeredByUserId,
                StartDate = courseOfMedicine.StartDate,
                EndDate = courseOfMedicine.EndDate,
                Instructions = courseOfMedicine.Instructions
            };

            if (solvedNested)
            {
                obj.Medicine = MedicineBusinessLogicEntityFramework.ConvertToEntityFramework(courseOfMedicine.Medicine);
            }

            return obj;
        }

        public static Domain.Treatments.CourseOfMedicine ConvertToDomain(CourseOfMedicine courseOfMedicine, bool solvedNested = false)
        {
            var obj = new Domain.Treatments.CourseOfMedicine
            {
                TreatmentId = courseOfMedicine.TreatmentId,
                MedicineId = courseOfMedicine.MedicineId,
                ScheduledDate = courseOfMedicine.ScheduledDate,
                VisitId = courseOfMedicine.VisitId,
                RecordedByUserId = courseOfMedicine.RecordedByUserId,
                AdministeredByUserId = courseOfMedicine.AdministeredByUserId,
                StartDate = courseOfMedicine.StartDate,
                EndDate = courseOfMedicine.EndDate,
                Instructions = courseOfMedicine.Instructions
            };

            if (solvedNested)
            {
                obj.Medicine = MedicineBusinessLogicEntityFramework.ConvertToDomain(courseOfMedicine.Medicine);
            }

            return obj;
        }
    }
}
