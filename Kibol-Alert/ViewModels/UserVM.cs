using Kibol_Alert.Models;

namespace Kibol_Alert.ViewModels
{
    public class UserVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ClubBasicVM Club { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }
}
