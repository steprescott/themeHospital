using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface ICourseOfMedicineBusinessLogic
    {
        bool CreateCauseOfMedicne(CourseOfMedicine courseOfMedicine);
        CourseOfMedicine GetCoursesOfMedicineWithId(Guid id);
        List<CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId);
        List<CourseOfMedicine> GetCoursesOfMedicinesForTeamByConsultantId(Guid userId);
        List<CourseOfMedicine> GetCourseOfMedicinesScheduledForPatientId(Guid patientId);
        bool AdministorCourseOfMedicineWithId(Guid id, Guid administoredByUserId);
    }
}
