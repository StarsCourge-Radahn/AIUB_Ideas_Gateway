using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string AdminPassword { get; set; }
        [Required]
        public string Role { get; set; } = "admin";

        public virtual ICollection<User> Users { get; set;}
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }

        public Admin() 
        {
            Users = new List<User>();
            Jobs = new List<Job>();
            Posts = new List<Post>();
            Sessions = new List<Session>();
        }

    }
}
