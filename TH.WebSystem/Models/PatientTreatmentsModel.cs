using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class PatientTreatmentsModel
    {
        public List<CourseOfMedicine> CoursesOfMedicines { get; set; }
        public List<Procedure> Procedures { get; set; }
        public Patient Patient { get; set; }

        public PatientTreatmentsModel()
        {
            CoursesOfMedicines = new List<CourseOfMedicine>();
            Procedures = new List<Procedure>();
        }
    }
}
