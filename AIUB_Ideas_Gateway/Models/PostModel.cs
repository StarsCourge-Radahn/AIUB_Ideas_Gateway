using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Ideas_Gateway.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}