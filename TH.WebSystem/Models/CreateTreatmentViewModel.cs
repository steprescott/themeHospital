using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class CreateTreatmentViewModel
    {
        [DisplayName("Patent full name")]
        public String PatientFullName { get; set; }

        [Display(Name = "Assigned to")]
        public List<StaffMember> MedicalStaff { get; set; }

        [Display(Name = "Operation")]
        public List<Operation> Operations { get; set; }

        [Display(Name = "Medicine")]
        public List<Medicine> Medicines { get; set; }

        [DisplayName("Visit ID")]
        public Guid VisitId { get; set; }

        [DisplayName("Recorded by staff member ID")]
        public Guid RecordedByStaffMemberId { get; set; }

        [DisplayName("Assigned to staff member ID")]
        public Guid AssignedToStaffMemberId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Note")]
        public String NoteContent { get; set; }

        [DisplayName("Selected operation ID")]
        public Guid SelectedOperationId { get; set; }

        [DisplayName("Selected medicine ID")]
        public Guid SelectedMedicineId { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Instructions")]
        public String Instructions { get; set; }
    }
}