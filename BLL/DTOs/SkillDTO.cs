using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Proficiency { get; set; }
        // Example: Beginner, Intermediate, Advanced
        public int CVId { get; set; }
    }
}
