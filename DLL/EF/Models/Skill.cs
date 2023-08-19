using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("CV")]
        public int CVId { get; set; }
        public virtual CV CV { get; set; }
    }
}
