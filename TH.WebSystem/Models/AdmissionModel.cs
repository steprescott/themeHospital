using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Other;

namespace TH.WebSystem.Models
{
    public class AdmissionModel
    {
        [DisplayName("Teams")]
        public List<Team> Teams { get; set; }

        [DisplayName("Patent ID")]
        public Guid PatientId { get; set; }

        [DisplayName("Team ID")]
        public Guid TeamId { get; set; }
    }
}
