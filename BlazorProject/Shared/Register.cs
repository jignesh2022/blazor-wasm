using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class Register
    {
        [Required]
        [StringLength(50, ErrorMessage = "Max. length is 50 chars. only")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max. length is 50 chars. only")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Max. length is 50 chars. only")]        
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Max. length is 10 chars. only")]            
        public string Password { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Max. length is 10 chars. only")]
        [Compare("Password")]        
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool Terms { get; set; } 
    }
}
