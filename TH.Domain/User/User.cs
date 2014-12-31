using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class User
    {
        public User()
        {
            Addresses = new List<Address>();
        }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public string FirstName { get; set; }

        public string OtherNames { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }

        public List<Address> Addresses { get; set; } 

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
