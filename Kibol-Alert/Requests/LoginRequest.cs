using System.ComponentModel.DataAnnotations;


namespace Kibol_Alert.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
