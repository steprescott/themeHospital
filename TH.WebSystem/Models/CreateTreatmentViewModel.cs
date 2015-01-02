using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class CreateTreatmentViewModel
    {
        public String PatientFullName { get; set; }

        [Display(Name = "Assigned to")]
        public List<StaffMember> MedicalStaff { get; set; }

        [Display(Name = "Operation")]
        public List<Operation> Operations { get; set; }

        [Display(Name = "Medicine")]
        public List<Medicine> Medicines { get; set; }

        public Guid VisitId { get; set; }

        public Guid RecordedByStaffMemberId { get; set; }

        public Guid AssignedToStaffMemberId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Note")]
        public String NoteContent { get; set; }

        public Guid SelectedOperationId { get; set; }

        public Guid SelectedMedicineId { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Instructions")]
        public String Instructions { get; set; }
    }
}