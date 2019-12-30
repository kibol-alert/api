using Kibol_Alert.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Kibol_Alert.Database
{
    public class DataInitialization
    {
        private readonly Kibol_AlertContext _context;
        private readonly UserManager<User> _userManager;
        public DataInitialization(Kibol_AlertContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void SeedUser()
        {
            if (_userManager.Users.FirstOrDefault(i => i.UserName == "Admin") == null)
            {
                User user = new User
                {
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    IsAdmin = true,
                    ClubId = _context.Clubs.FirstOrDefault(i => i.Name == "Cracovia").Id
                };

                var result = _userManager.CreateAsync(user, "Password123.").Result;
            }
        }

        public void SeedClubs()
        {
            if (_context.Clubs.FirstOrDefault(i => i.Name == "Cracovia") == null)
            {
                _context.Clubs.Add(new Club { Name = "Arka Gdynia", League = "Ekstraklasa", City = "Gdynia" });
                _context.Clubs.Add(new Club { Name = "Cracovia", League = "Ekstraklasa", City = "Kraków" });
                _context.Clubs.Add(new Club { Name = "Górnik Zabrze", League = "Ekstraklasa", City = "Zabrze" });
                _context.Clubs.Add(new Club { Name = "Jagiellonia Białystok", League = "Ekstraklasa", City = "Białystok" });
                _context.Clubs.Add(new Club { Name = "KGHM Zagłębie Lubin", League = "Ekstraklasa", City = "Lubin" });
                _context.Clubs.Add(new Club { Name = "Korona Kielce", League = "Ekstraklasa", City = "Kielce" });
                _context.Clubs.Add(new Club { Name = "Lech Poznań", League = "Ekstraklasa", City = "Poznań" });
                _context.Clubs.Add(new Club { Name = "Lechia Gdańsk", League = "Ekstraklasa", City = "Gdańsk" });
                _context.Clubs.Add(new Club { Name = "Legia Warszawa", League = "Ekstraklasa", City = "Warszawa" });
                _context.Clubs.Add(new Club { Name = "ŁKS Łódź", League = "Ekstraklasa", City = "Łódź" });
                _context.Clubs.Add(new Club { Name = "Piast Gliwice", League = "Ekstraklasa", City = "Gliwice" });
                _context.Clubs.Add(new Club { Name = "Pogoń Szczecin", League = "Ekstraklasa", City = "Szczecin" });
                _context.Clubs.Add(new Club { Name = "Raków Częstochowa", League = "Ekstraklasa", City = "Częstochowa" });
                _context.Clubs.Add(new Club { Name = "Śląsk Wrocław", League = "Ekstraklasa", City = "Wrocław" });
                _context.Clubs.Add(new Club { Name = "Wisła Kraków", League = "Ekstraklasa", City = "Kraków" });
                _context.Clubs.Add(new Club { Name = "Wisła Płock", League = "Ekstraklasa", City = "Płock" });
                _context.SaveChangesAsync();
            }
        }
    }
}
