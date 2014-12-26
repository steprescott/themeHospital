using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class AddPatientViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Other Names")]
        public string OtherNames { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Number")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Number")]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public AddressModel Address { get; set; }

        public AddPatientViewModel()
        {
            Address = new AddressModel();
        }
    }
}