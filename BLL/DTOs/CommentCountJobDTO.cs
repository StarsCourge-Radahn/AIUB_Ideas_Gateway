using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentCountJobDTO
    {
        public int? JobId { get; set; }
        public string JobContent { get; set; } // Add this property
        public int CommentCount { get; set; }
    }
}
