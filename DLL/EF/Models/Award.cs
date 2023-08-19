using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class Award
    {
        [Key]
        public int AwardId { get; set; }
        public string AwardName { get; set; }
        public string AwardingInstitution { get; set; }
        public DateTime DateReceived { get; set; }

        [ForeignKey("CV")]
        public int CVId { get; set; }
        public virtual CV CV { get; set; }
    }
}
