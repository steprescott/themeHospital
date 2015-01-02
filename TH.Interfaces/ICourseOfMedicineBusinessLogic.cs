using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface ICourseOfMedicineBusinessLogic
    {
        bool CreateCauseOfMedicne(CourseOfMedicine courseOfMedicine);
        List<CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId);
        List<CourseOfMedicine> GetCoursesOfMedicinesForTeamByConsultantId(Guid userId);
        List<CourseOfMedicine> GetProceduresScheduledForPatientId(Guid patientId);
    }
}
