using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TH.WebSystem.Models
{
    public class AddressModel
    {
        [Required]
        [Display(Name = "Address Line One")]
        public string LineOne { get; set; }

        [Required]
        [Display(Name = "Address Line Two")]
        public string LineTwo { get; set; }

        [Display(Name = "Address Line Three")]
        public string LineThree { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Post code")]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }

        [Required]
        [Display(Name = "Is current address")]
        public bool IsCurrentAddress { get; set; }
    }
}
