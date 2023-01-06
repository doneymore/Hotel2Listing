using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Dtos.UserDto
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        //[Required]
      
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} Characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
