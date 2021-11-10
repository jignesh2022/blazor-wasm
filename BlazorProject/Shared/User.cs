using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email not valid.")]        
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Min. length of password is 6 chars.")]
        public string Password {get; set; }
        public string Salt { get; set; }
        /// <summary>
        /// Roles can be comma seperated values
        /// </summary>
        public string Roles { get; set; }
    }
}
