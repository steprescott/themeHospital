using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TH.Domain.Other
{
    public class Address
    {
        [DisplayName(@"Address ID")]
        public Guid AddressId { get; set; }

        [DisplayName(@"Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName(@"Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName(@"Line 3")]
        public string AddressLine3 { get; set; }

        [DisplayName(@"City")]
        public string City { get; set; }

        [DisplayName(@"Post code")]
        public string PostCode { get; set; }

        [DisplayName(@"Is current address")]
        public bool IsCurrentAddress { get; set; }
    }
}
