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
            if (_context.Clubs.FirstOrDefault(i=> i.Name == "Cracovia") == null)
            {
                //Ekstraklasa
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

                //I Liga
                _context.Clubs.Add(new Club { Name = "Warta Poznań", League = "I Liga", City = "Poznań" });
                _context.Clubs.Add(new Club { Name = "Stal Mielec", League = "I Liga", City = "Mielec" });
                _context.Clubs.Add(new Club { Name = "Podbeskidzie Bielsko-Biała", League = "I Liga", City = "Bielsko-Biała" });
                _context.Clubs.Add(new Club { Name = "Radomiak Radom", League = "I Liga", City = "Radom" });
                _context.Clubs.Add(new Club { Name = "Olimpia Grudziądz", League = "I Liga", City = "Grudziądz" });
                _context.Clubs.Add(new Club { Name = "Miedź Legnica", League = "I Liga", City = "Legnica" });
                _context.Clubs.Add(new Club { Name = "GKS Tychy", League = "I Liga", City = "Tychy" });
                _context.Clubs.Add(new Club { Name = "GKS 1962 Jastrzębie", League = "I Liga", City = "Jastrzębie Zdrój" });
                _context.Clubs.Add(new Club { Name = "Bruk-Bet Termalica Nieciecza", League = "I Liga", City = "Nieciecza" });
                _context.Clubs.Add(new Club { Name = "Zagłębie Sosnowiec", League = "I Liga", City = "Sosnowiec" });
                _context.Clubs.Add(new Club { Name = "Stomil Olsztyn", League = "I Liga", City = "Olsztyn" });
                _context.Clubs.Add(new Club { Name = "Sandecja Nowy Sącz", League = "I Liga", City = "Nowy Sącz" });
                _context.Clubs.Add(new Club { Name = "GKS Bełchatów", League = "I Liga", City = "Bełchatów" });
                _context.Clubs.Add(new Club { Name = "Puszcza Niepołomice", League = "I Liga", City = "Niepołomice" });
                _context.Clubs.Add(new Club { Name = "Odra Opole", League = "I Liga", City = "Opole" });
                _context.Clubs.Add(new Club { Name = "Chrobry Głogów", League = "I Liga", City = "Głogów" });
                _context.Clubs.Add(new Club { Name = "Wigry Suwałki", League = "I Liga", City = "Suwałki" });
                _context.Clubs.Add(new Club { Name = "Chojniczanka Chojnice", League = "I Liga", City = "Chojnice" });

                //II Liga
                _context.Clubs.Add(new Club { Name = "Widzew Łódź", League = "II Liga", City = "Łódź" });
                _context.Clubs.Add(new Club { Name = "Górnik Łęczna", League = "II Liga", City = "Łęczna" });
                _context.Clubs.Add(new Club { Name = "GKS Katowice", League = "II Liga", City = "Katowice" });
                _context.Clubs.Add(new Club { Name = "Resovia", League = "II Liga", City = "Rzeszów" });
                _context.Clubs.Add(new Club { Name = "Olimpia Elbląg", League = "II Liga", City = "Elbląg" });
                _context.Clubs.Add(new Club { Name = "Stal Rzeszów", League = "II Liga", City = "Rzeszów" });
                _context.Clubs.Add(new Club { Name = "Bytovia Bytów", League = "II Liga", City = "Bytów" });
                _context.Clubs.Add(new Club { Name = "Błękitni Stargard", League = "II Liga", City = "Stargard" });
                _context.Clubs.Add(new Club { Name = "Znicz Pruszków", League = "II Liga", City = "Pruszków" });
                _context.Clubs.Add(new Club { Name = "Elana Toruń", League = "II Liga", City = "Toruń" });
                _context.Clubs.Add(new Club { Name = "Garbarnia Kraków", League = "II Liga", City = "Kraków" });
                _context.Clubs.Add(new Club { Name = "Górnik Polkowice", League = "II Liga", City = "Polkowice" });
                _context.Clubs.Add(new Club { Name = "Pogoń Siedlce", League = "II Liga", City = "Siedlce" });
                _context.Clubs.Add(new Club { Name = "Lech II Poznań", League = "II Liga", City = "Poznań" });
                _context.Clubs.Add(new Club { Name = "Stal Stalowa Wola", League = "II Liga", City = "Stalowa Wola" });
                _context.Clubs.Add(new Club { Name = "Skra Częstochowa", League = "II Liga", City = "Częstochowa" });
                _context.Clubs.Add(new Club { Name = "Legionovia Legionowo", League = "II Liga", City = "Legionowo" });
                _context.Clubs.Add(new Club { Name = "Gryf Wejherowo", League = "II Liga", City = "Wejherowo" });
                _context.SaveChangesAsync();
            }
        }
    }
}
