using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.WebSystem.Models
{
    public class ViewTreatmentModel
    {
        [DisplayName("Course of medicines")]
        public List<CourseOfMedicine> CoursesOfMedicines { get; set; }

        [DisplayName("Procedures")]
        public List<Procedure> Procedures { get; set; }

        [DisplayName("Teams course of medicines")]
        public List<CourseOfMedicine> TeamsCourseOfMedicines { get; set; }

        [DisplayName("Teams procedures")]
        public List<Procedure> TeamsProcedures { get; set; } 

        public ViewTreatmentModel()
        {
            CoursesOfMedicines = new List<CourseOfMedicine>();
            Procedures = new List<Procedure>();

            TeamsCourseOfMedicines = new List<CourseOfMedicine>();
            TeamsProcedures = new List<Procedure>();
        }
    }
}
