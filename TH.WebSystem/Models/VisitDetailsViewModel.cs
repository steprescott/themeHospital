using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TH.Domain.Other;

namespace TH.WebSystem.Models
{
    public class VisitDetailsViewModel
    {
        [DisplayName("Visit")]
        public Visit Visit { get; set; }
    }
}