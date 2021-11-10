using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Shared
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Required]
        [MaxLength(200,ErrorMessage = "Max. length for Title is 300 chars.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Max. length for Title is 300 chars.")]
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }
                
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public string CreatedBy { get; set; }
    }
}
