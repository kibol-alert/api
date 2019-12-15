using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kibol_Alert.Migrations
{
    public static class SeedData
    {
        public static void Initialize(Kibol_AlertContext context)
        {
            context.Database.EnsureCreated();
        //??    context.Database.EnsureCreatedAsync(); 
            if (!context.Clubs.CountAsync()) //?
            {
                context.Clubs.Add(new Club { Name = "Arka Gdynia", League = "Ekstraklasa", City = "Gdynia" });
                context.Clubs.Add(new Club { Name = "Cracovia", League = "Ekstraklasa", City = "Kraków" });
                context.Clubs.Add(new Club { Name = "Górnik Zabrze", League = "Ekstraklasa", City = "Zabrze" });
                context.Clubs.Add(new Club { Name = "Jagiellonia Białystok", League = "Ekstraklasa", City = "Białystok" });
                context.Clubs.Add(new Club { Name = "KGHM Zagłębie Lubin", League = "Ekstraklasa", City = "Lubin" });
                context.Clubs.Add(new Club { Name = "Korona Kielce", League = "Ekstraklasa", City = "Kielce" });
                context.Clubs.Add(new Club { Name = "Lech Poznań", League = "Ekstraklasa", City = "Poznań" });
                context.Clubs.Add(new Club { Name = "Lechia Gdańsk", League = "Ekstraklasa", City = "Gdańsk" });
                context.Clubs.Add(new Club { Name = "Legia Warszawa", League = "Ekstraklasa", City = "Warszawa" });
                context.Clubs.Add(new Club { Name = "ŁKS Łódź", League = "Ekstraklasa", City = "Łódź" });
                context.Clubs.Add(new Club { Name = "Piast Gliwice", League = "Ekstraklasa", City = "Gliwice" });
                context.Clubs.Add(new Club { Name = "Pogoń Szczecin", League = "Ekstraklasa", City = "Szczecin" });
                context.Clubs.Add(new Club { Name = "Raków Częstochowa", League = "Ekstraklasa", City = "Częstochowa" });
                context.Clubs.Add(new Club { Name = "Śląsk Wrocław", League = "Ekstraklasa", City = "Wrocław" });
                context.Clubs.Add(new Club { Name = "Wisła Kraków", League = "Ekstraklasa", City = "Kraków" });
                context.Clubs.Add(new Club { Name = "Wisła Płock", League = "Ekstraklasa", City = "Płock" });
                context.SaveChanges();
            }
            if (context.Users.FirstOrDefaultAsync(i => i.Id == Id)) //?
            {
                context.Users.Add(new User { UserName = "Admin", NormalizedUserName = "Admin", Email = "admin@example.com", NormalizedEmail = "admin@example.com", IsAdmin = true, EmailConfirmed = true });
                context.SaveChanges();
            }
        }

        /*
        public static void Initialize(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>().HasData(

                new Club { Name = "Arka Gdynia", League = "Ekstraklasa", City = "Gdynia" },
                new Club { Name = "Cracovia", League = "Ekstraklasa", City = "Kraków" },
                new Club { Name = "Górnik Zabrze", League = "Ekstraklasa", City = "Zabrze" },
                new Club { Name = "Jagiellonia Białystok", League = "Ekstraklasa", City = "Białystok" },
                new Club { Name = "KGHM Zagłębie Lubin", League = "Ekstraklasa", City = "Lubin" },
                new Club { Name = "Korona Kielce", League = "Ekstraklasa", City = "Kielce" },
                new Club { Name = "Lech Poznań", League = "Ekstraklasa", City = "Poznań" },
                new Club { Name = "Lechia Gdańsk", League = "Ekstraklasa", City = "Gdańsk" },
                new Club { Name = "Legia Warszawa", League = "Ekstraklasa", City = "Warszawa" },
                new Club { Name = "ŁKS Łódź", League = "Ekstraklasa", City = "Łódź" },
                new Club { Name = "Piast Gliwice", League = "Ekstraklasa", City = "Gliwice" },
                new Club { Name = "Pogoń Szczecin", League = "Ekstraklasa", City = "Szczecin" },
                new Club { Name = "Raków Częstochowa", League = "Ekstraklasa", City = "Częstochowa" },
                new Club { Name = "Śląsk Wrocław", League = "Ekstraklasa", City = "Wrocław" },
                new Club { Name = "Wisła Kraków", League = "Ekstraklasa", City = "Kraków" },
                new Club { Name = "Wisła Płock", League = "Ekstraklasa", City = "Płock" }
            );

            modelBuilder.Entity<User>().HasData(

                new User { UserName = "Admin", NormalizedUserName = "Admin", Email = "admin@example.com", NormalizedEmail = "admin@example.com", IsAdmin = true, EmailConfirmed = true }
            );
        }
        */
    }
}
