namespace Kibol_Alert.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FavoriteClub { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsBanned { get; set; } = false;
    }
}
