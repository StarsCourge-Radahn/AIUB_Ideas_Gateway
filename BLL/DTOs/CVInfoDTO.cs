using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CVInfoDTO 
    {
        public List<AcademicQualificationDTO> AcademicQualifications { get; set; }
        public List<AwardDTO> Awards { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
        public List<SkillDTO> Skills { get; set; }
        public List<ThesisPaperDTO> ThesisPapers { get; set; }
    }
}
