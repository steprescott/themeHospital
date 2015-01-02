using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Interfaces
{
    public interface ICourseOfMedicineBusinessLogic
    {
        bool CreateCauseOfMedicne(Domain.Treatments.CourseOfMedicine courseOfMedicine);
    }
}
