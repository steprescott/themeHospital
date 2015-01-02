using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.Other;

namespace TH.WebSystem.Models
{
    public class PatientOptionsViewModel
    {
        [DisplayName("Patient ID")]
        public Guid PatientId { get; set; }

        [DisplayName("Current visit")]
        public Visit CurrentVisit { get; set; }
        public Ward AvailabeBeds { get; set; }
    }
}