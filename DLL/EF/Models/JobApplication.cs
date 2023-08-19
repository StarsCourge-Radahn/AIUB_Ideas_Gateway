using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public DateTime AppliedOn { get; set; } = DateTime.Now; // To know when the user applied

        public int ApplicationStatus { get; set; } = 0;
        // 0 -> initial status
        // 1 -> received
        // 2 -> shortlisted
        // 3 -> rejected
        // 4 -> accepted
    }
}
