﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "user";

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Job> Jobs{ get; set; }
        public virtual ICollection<Session> Sessions{ get; set; }


    }
}