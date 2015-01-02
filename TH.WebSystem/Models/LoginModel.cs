using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Username")]
        public String Username { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [DisplayName("Password")]
        public String Password { get; set; }
    }
}