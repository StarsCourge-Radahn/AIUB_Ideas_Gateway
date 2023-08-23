using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ExperienceDTO
    {
        public int ExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CVId { get; set; }
    }
}
