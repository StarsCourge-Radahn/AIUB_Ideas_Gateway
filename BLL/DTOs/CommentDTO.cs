using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentDTO
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? UserID { get; set; }
        public int? PostID { get; set; }
        public int? JobID { get; set; }

        public bool IsBan { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
