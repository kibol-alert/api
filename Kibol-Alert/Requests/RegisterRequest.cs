using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Requests
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string ConfirmedPassword { get; set; }
    }
}
