using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int CVId { get; set; }
        public virtual CV CV { get; set; }
    }
}
