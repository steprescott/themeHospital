using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface ICourseOfMedicineBusinessLogic
    {
        bool CreateCauseOfMedicne(CourseOfMedicine courseOfMedicine);
        Domain.Treatments.CourseOfMedicine GetCoursesOfMedicineWithId(Guid id);
        List<CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId);
        List<CourseOfMedicine> GetCoursesOfMedicinesForTeamByConsultantId(Guid userId);
        List<Domain.Treatments.CourseOfMedicine> GetCourseOfMedicinesScheduledForPatientId(Guid patientId);
        bool AdministorCourseOfMedicineWithId(Guid id, Guid administoredByUserId);
    }
}
