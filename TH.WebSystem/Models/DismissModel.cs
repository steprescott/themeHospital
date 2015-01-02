using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class DismissModel
    {
        [DisplayName("Patent ID")]
        public Guid PatientId { get; set; }

        [DisplayName("Patent")]
        public Patient Patient { get; set; }
    }
}
