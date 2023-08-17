using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF.Models
{
    public class ThesisPaper
    {
        [Key]
        public int ThesisId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CoAuthors { get; set; } 
        // Can be a comma-separated list or you can create another model for CoAuthors

        public int CVId { get; set; }
        public virtual CV CV { get; set; }
    }
}
