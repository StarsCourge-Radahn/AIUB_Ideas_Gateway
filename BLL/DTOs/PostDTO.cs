using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostDTO
    {

        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsBan { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public DateTime? UpdatedAt { get; set; }

        public int UserID { get; set; }
    }
}
