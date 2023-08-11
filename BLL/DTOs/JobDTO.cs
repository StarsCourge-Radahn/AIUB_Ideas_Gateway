using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobDTO
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsBan { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public int UserID { get; set; }
    }
}
