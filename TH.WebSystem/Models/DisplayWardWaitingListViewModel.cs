using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Domain.Other;
using TH.Domain.User;
using TH.Domain.Wards;

namespace TH.WebSystem.Models
{
    public class DisplayWardWaitingListViewModel
    {
        public List<Patient> Patients {get; set;} 

    }
}