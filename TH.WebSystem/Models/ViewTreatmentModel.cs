using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Treatments;

namespace TH.WebSystem.Models
{
    public class ViewTreatmentModel
    {
        public List<CourseOfMedicine> CoursesOfMedicines { get; set; }
        public List<Procedure> Procedures { get; set; }

        public List<CourseOfMedicine> TeamsCourseOfMedicines { get; set; }
        public List<Procedure> TeamsProcedures { get; set; } 
    }
}
