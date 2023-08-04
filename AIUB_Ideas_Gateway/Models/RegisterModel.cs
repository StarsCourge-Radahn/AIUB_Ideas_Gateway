using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIUB_Ideas_Gateway.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}