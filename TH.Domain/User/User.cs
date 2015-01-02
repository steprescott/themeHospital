using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TH.Domain.Other;

namespace TH.Domain.User
{
    public class User
    {
        [DisplayName(@"User ID")]
        public Guid UserId { get; set; }

        [DisplayName(@"Date created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Other names")]
        public string OtherNames { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Contact number")]
        public string ContactNumber { get; set; }

        [DisplayName("Address")]
        public List<Address> Addresses { get; set; } 

        [DisplayName("Full name")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        public User()
        {
            Addresses = new List<Address>();
        }
    }
}
