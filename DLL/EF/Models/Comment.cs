using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public int? PostID { get; set; }
        public virtual Post Post { get; set; }

        public int? JobID { get; set; }
        public virtual Job Job { get; set; }
    }
}
