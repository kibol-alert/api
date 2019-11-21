using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Requests
{
    public class RegisterRequest : LoginRequest
    {
        
        public RegisterRequest(string confirmedPassword)
        {
            this.ConfirmedPassword = confirmedPassword;
               
        }
        
        public string ConfirmedPassword { get; set; }
    }
}
