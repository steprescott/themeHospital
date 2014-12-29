using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public System.DateTime DateCreated { get; set; }

        public string Firstname { get; set; }

        public string OtherNames { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }

        public List<Address> Addresses { get; set; } 
    }
}
