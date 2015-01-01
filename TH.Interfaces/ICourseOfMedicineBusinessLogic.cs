using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Interfaces
{
    public interface ICourseOfMedicineBusinessLogic
    {
        bool CreateCauseOfMedicne(Domain.Treatments.CourseOfMedicine courseOfMedicine);
    }
}
