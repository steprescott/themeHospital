using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class DismissModel
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
