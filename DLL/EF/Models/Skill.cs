using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Proficiency { get; set; } 
        // Example: Beginner, Intermediate, Advanced

        public int CVId { get; set; }
        public virtual CV CV { get; set; }
    }
}
