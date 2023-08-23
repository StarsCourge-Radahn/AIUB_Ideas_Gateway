using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AwardDTO
    {
      
        public int AwardId { get; set; }
        public string AwardName { get; set; }
        public string AwardingInstitution { get; set; }
        public DateTime DateReceived { get; set; }
        public int CVId { get; set; }
    }
}
