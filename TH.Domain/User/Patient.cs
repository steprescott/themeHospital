using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.User
{
    public class Patient
    {
        public Patient()
        {
            Addresses = new List<Address>();
        }

        public Guid UserId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string OtherNames { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; }

        public List<Address> Addresses { get; set; } 

    }
}
