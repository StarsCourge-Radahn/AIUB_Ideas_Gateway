using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "user";
        [Required]
        public bool IsBan { get; set; } = false;
        [Required]
        public bool TemporaryBan { get; set; } = false;
        [Required]
        public bool IsDeleted { get; set; } = false;

        //[ForeignKey("CV")]
        //public int? CvId { get; set; }
        //public CV CV { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

        public virtual ICollection<Comment> Comments { get; set; }= new List<Comment>();

        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

        public virtual ICollection<OTP> OTPs { get; set; } = new List<OTP>();
    }
}
