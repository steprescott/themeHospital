using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class PatientOptionsViewModel
    {
        [DisplayName("Patient ID")]
        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}