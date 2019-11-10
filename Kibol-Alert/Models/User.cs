using Microsoft.AspNetCore.Identity;

namespace Kibol_Alert.Models
{
    public class User: IdentityUser<int>
    {
        public int UserId { get; set; }
        public string FavoriteClub { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsBanned { get; set; } = false;
    }
}
