using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TH.Domain.Treatment;

namespace TH.WebSystem.Models
{
    public class NewTreatmentViewModel
    {
        public List<Operation> Operations { get; set; }

        public Guid SelectedOperationId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ScheduledDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdministered { get; set; }
    }
}