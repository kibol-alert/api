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
        public DbSet<ClubRelation> ClubRelations {get; set;}
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Club>()
                .HasMany(i => i.Fans)
                .WithOne(i => i.Club);

            modelBuilder
                .Entity<ClubRelation>()
                .HasOne(i => i.FirtClub)
                .WithMany(i => i.ClubRelations);

            modelBuilder
                .Entity<ClubRelation>()
                .HasOne(i => i.SecondClub)
                .WithMany(i => i.ClubRelations);

            //Work in progress
        }
    }
}
