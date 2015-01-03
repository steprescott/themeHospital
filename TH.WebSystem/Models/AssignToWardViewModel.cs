using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.Wards;

namespace TH.WebSystem.Models
{
    public class AssignToWardViewModel
    {
        [DisplayName("Patient ID")]
        public Guid PatientId { get; set; }

        [DisplayName("Wards")]
        public List<Ward> Wards { get; set; }

        public AssignToWardViewModel()
        {
            Wards = new List<Ward>();
        }
    }
}