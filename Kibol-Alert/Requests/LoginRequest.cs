using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Requests
{
    public class LoginRequest
    {
        public LoginRequest(string email, string userName, string password) 
        {
            this.Email = email;
                this.UserName = userName;
                this.Password = password;
               
        }
                public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
