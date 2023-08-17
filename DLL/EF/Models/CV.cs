using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class CV
    {
        [Key]
        public int CVId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<AcademicQualification> AcademicQualifications { get; set; } = new List<AcademicQualification>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public virtual ICollection<ThesisPaper> ThesisPapers { get; set; } = new List<ThesisPaper>();
        public virtual ICollection<Award> Awards { get; set; } = new List<Award>();
    }
}
