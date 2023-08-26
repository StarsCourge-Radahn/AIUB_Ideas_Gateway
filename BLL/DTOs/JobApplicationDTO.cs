using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobApplicationDTO
    {
        public int JobApplicationId { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public DateTime AppliedOn { get; set; } = DateTime.Now;
        public int ApplicationStatus { get; set; } = 0;

    }
}
