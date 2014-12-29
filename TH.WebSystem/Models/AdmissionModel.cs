using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.WebSystem.Models
{
    public class AdmissionModel
    {
        public List<Team> Teams { get; set; } 
        public Guid PatientId { get; set; }
        public Guid TeamId { get; set; }
    }
}
