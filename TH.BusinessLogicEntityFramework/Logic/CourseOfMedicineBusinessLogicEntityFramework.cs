using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class CourseOfMedicineBusinessLogicEntityFramework : ICourseOfMedicineBusinessLogic
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
                CourseOfMedicine efObject = ReflectiveMapperService.ConvertItem<Domain.Treatments.CourseOfMedicine, CourseOfMedicine>(courseOfMedicine);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public List<Domain.Treatments.CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId)
        {
            var coursesOfMedicines = _unitOfWork.GetAll<CourseOfMedicine>().ToList();

            coursesOfMedicines = coursesOfMedicines.Where(com => com.AdministeredByUserId == userId).ToList();

            return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<CourseOfMedicine, Domain.Treatments.CourseOfMedicine>(com)).ToList();
        }

        public List<Domain.Treatments.CourseOfMedicine> GetCoursesOfMedicinesForTeamByConsultantId(Guid userId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(userId);

            if (consultant != null)
            {
                var consultantTeam = consultant.Team;
                var coursesOfMedicines = _unitOfWork.GetAll<CourseOfMedicine>().ToList();

                coursesOfMedicines = coursesOfMedicines.Where(com => consultantTeam.Doctors.Select(d => d.UserId).Contains(com.AssignedToUserId)).ToList();

                return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<CourseOfMedicine, Domain.Treatments.CourseOfMedicine>(com)).ToList();
            }
            return new List<Domain.Treatments.CourseOfMedicine>();
        }

        public List<Domain.Treatments.CourseOfMedicine> GetProceduresScheduledForPatientId(Guid patientId)
        {
            var courseOfMedicines = _unitOfWork.GetAll<CourseOfMedicine>().ToList();

            courseOfMedicines = courseOfMedicines.Where(p => p.Visit.PatientUserId == patientId).ToList();

            return courseOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<CourseOfMedicine, Domain.Treatments.CourseOfMedicine>(com)).ToList();
        }
    }
}
