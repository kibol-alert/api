using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kibol_Alert.Models;

namespace Kibol_Alert.Database
{
    public class Kibol_AlertContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public Kibol_AlertContext(DbContextOptions<Kibol_AlertContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubRelations> Relations {get; set;}
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                    .Entity<Club>()
                    .HasMany(i => i.ClubRelations);
            //Work in progress
        }
    }
}
