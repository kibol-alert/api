using Microsoft.AspNetCore.Identity;

namespace Kibol_Alert.Models
{
    public class User: IdentityUser
    {
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsBanned { get; set; } = false;
    }
}