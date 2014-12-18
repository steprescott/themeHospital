using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display (Name = "Password")]
        public String Password { get; set; }
    }
}