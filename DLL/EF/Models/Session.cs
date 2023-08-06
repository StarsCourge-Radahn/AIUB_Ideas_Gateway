using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
