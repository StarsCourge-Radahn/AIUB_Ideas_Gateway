using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Ideas_Gateway.Models
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; } 
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set;} 
    }
}