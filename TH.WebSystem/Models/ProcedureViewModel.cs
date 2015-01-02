using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class ProcedureViewModel
    {
        [DisplayName("Procedure")]
        public Procedure Procedure { get; set; }

        [DisplayName("Recorded by")]
        public StaffMember RecordedBy { get; set; }

        [DisplayName("Assigned to")]
        public StaffMember AssignedTo { get; set; }

        [DisplayName("Administered by")]
        public StaffMember AdministeredBy { get; set; }

        [DisplayName("Administered by")]
        public List<StaffMember> MedicalStaff { get; set; }

        [DisplayName("Treatment ID")]
        public Guid TreatmentId { get; set; }

        [DisplayName("Administered by user ID")]
        public Guid AdministeredByUserId { get; set; }
    }
}