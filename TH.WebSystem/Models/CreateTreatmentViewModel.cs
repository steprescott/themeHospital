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
        public List<Operation> Operations { get; set; }

        public Guid SelectedOperationId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ScheduledDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdministered { get; set; }

        public String NoteContent { get; set; }

        public StaffMember RecordedBy { get; set; }

        public StaffMember AdministeredBy { get; set; }
    }
}