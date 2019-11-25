using System.ComponentModel.DataAnnotations;

namespace Kibol_Alert.Requests
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string ConfirmedPassword { get; set; }
        public string Club { get; set; }
    }
}
