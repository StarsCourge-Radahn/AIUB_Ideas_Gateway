using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentCountDTO
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int CommentCount { get; set; }
    }
}
