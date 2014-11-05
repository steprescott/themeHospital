using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Domain
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string LineThree { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public bool IsCurrentAddress { get; set; }
    }
}
