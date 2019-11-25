using Kibol_Alert.Models;

namespace Kibol_Alert.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Club Club { get; set; }
        public bool IsBanned { get; set; } = false;
    }
}
