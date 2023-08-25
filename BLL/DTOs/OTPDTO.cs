using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OTPDTO
    {
        public int OTPId { get; set; }
        public string OTPName { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; } = false;
        public int UserID { get; set; }
    }
}
