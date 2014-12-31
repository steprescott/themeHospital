using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Domain.Other;

namespace TH.WebSystem.Models
{
    public class PatientOptionsViewModel
    {
        public Guid PatientId { get; set; }
        public Guid VisitId { get; set; }
    }
}