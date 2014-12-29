using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Domain.Other
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public bool IsCurrentAddress { get; set; }
    }
}
