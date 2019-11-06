using Kibol_Alert.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Kibol_Alert.Database
{
    public class Kibol_AlertContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public Kibol_AlertContext(DbContextOptions<Kibol_AlertContext> options)
            : base(options)
        {
        }

    }
}
