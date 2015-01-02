using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.Other;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class VisitDetailsViewModel
    {
        [DisplayName("Visit")]
        public Visit Visit { get; set; }

        [DisplayName("Procedures")]
        public List<Procedure> Procedures { get; set; }

        [DisplayName("Course of medicines")]
        public List<CourseOfMedicine> CourseOfMedicines { get; set; }
    }
}