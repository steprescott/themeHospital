using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TH.WebSystem.Models
{
    public class RefuseTreatmentModel
    {
        public Guid TreatmentId { get; set; }
        public string TreatmentName { get; set; }

        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Reason for refusal")]
        public string RefusalReason { get; set; }
    }
}
