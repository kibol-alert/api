using System.ComponentModel.DataAnnotations;

namespace Kibol_Alert.Requests
{
    public class RegisterRequest : LoginRequest
    {
        public string Email { get; set; }
        [Required]
        public string ConfirmedPassword { get; set; }
        public int ClubId { get; set; }
    }
}
