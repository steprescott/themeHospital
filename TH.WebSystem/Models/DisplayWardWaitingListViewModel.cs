using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.WebSystem.Models
{
    public class DisplayWardWaitingListViewModel
    {
        public List<Ward> Wards;
        public List<Patient> Patients; 
    }
}