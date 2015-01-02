using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Domain.Wards;

namespace TH.WebSystem.Models
{
    public class DisplayWardsViewModel
    {
        public List<Ward> Wards { get; set; }
        public Guid PatientId { get; set; }
        public DisplayWardsViewModel()
        {
            Wards = new List<Ward>();
        }
    }
}