using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using CourseOfMedicine = TH.Domain.Treatments.CourseOfMedicine;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class CourseOfMedicineBusinessLogicEntityFramework : ICourseOfMedicineBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseOfMedicineBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateCauseOfMedicne(CourseOfMedicine courseOfMedicine)
        {
            try
            {
                UnitOfWorkEntityFramework.CourseOfMedicine efObject = ReflectiveMapperService.ConvertItem<CourseOfMedicine, UnitOfWorkEntityFramework.CourseOfMedicine>(courseOfMedicine);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public CourseOfMedicine GetCoursesOfMedicineWithId(Guid id)
        {
            var coursesOfMedicine = _unitOfWork.GetById<UnitOfWorkEntityFramework.CourseOfMedicine>(id);
            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.CourseOfMedicine, CourseOfMedicine>(coursesOfMedicine);
        }

        public List<CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId)
        {
            var coursesOfMedicines = _unitOfWork.GetAll<UnitOfWorkEntityFramework.CourseOfMedicine>().ToList();

            coursesOfMedicines = coursesOfMedicines.Where(com => com.AssignedToUserId == userId).ToList();

            return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.CourseOfMedicine, CourseOfMedicine>(com)).ToList();
        }

        public List<CourseOfMedicine> GetCoursesOfMedicinesForTeamByConsultantId(Guid userId)
        {
            var consultant = _unitOfWork.GetById<Consultant>(userId);

            if (consultant != null)
            {
                var consultantTeam = consultant.Team;
                var coursesOfMedicines = _unitOfWork.GetAll<UnitOfWorkEntityFramework.CourseOfMedicine>().ToList();

                coursesOfMedicines = coursesOfMedicines.Where(com => consultantTeam.Doctors.Select(d => d.UserId).Contains(com.AssignedToUserId)).ToList();

                return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.CourseOfMedicine, CourseOfMedicine>(com)).ToList();
            }
            return new List<CourseOfMedicine>();
        }

        public List<CourseOfMedicine> GetCourseOfMedicinesScheduledForPatientId(Guid patientId)
        {
            var courseOfMedicines = _unitOfWork.GetAll<UnitOfWorkEntityFramework.CourseOfMedicine>().ToList();

            courseOfMedicines = courseOfMedicines.Where(p => p.Visit.PatientUserId == patientId).ToList();

            return courseOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.CourseOfMedicine, CourseOfMedicine>(com)).ToList();
        }

        public bool AdministorCourseOfMedicineWithId(Guid id, Guid administoredByUserId)
        {
            try
            {
                var efCourseOfMedicines = _unitOfWork.GetById<UnitOfWorkEntityFramework.CourseOfMedicine>(id);
                efCourseOfMedicines.AdministeredByUserId = administoredByUserId;
                _unitOfWork.Update(efCourseOfMedicines);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
