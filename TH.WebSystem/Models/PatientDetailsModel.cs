using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class PatientDetailsModel
    {
        [DisplayName("Patient")]
        public Patient Patient { get; set; }
    }
}
