using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class OTP
    {
        [Key]
        public int OTPId { get; set; }
        public string OTPName { get; set;}
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }


    }
}
