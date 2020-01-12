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
                _context.Clubs.Add(new Club { Name = "Arka Gdynia", League = "Ekstraklasa", City = "Gdynia", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737707/clubs/arka_gdynia_ddsxzc.png" });
                _context.Clubs.Add(new Club { Name = "Cracovia", League = "Ekstraklasa", City = "Kraków", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737720/clubs/cracovia_bzfj4w.png" });
                _context.Clubs.Add(new Club { Name = "Górnik Zabrze", League = "Ekstraklasa", City = "Zabrze", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737709/clubs/gornik_zabrze_e50kap.png" });
                _context.Clubs.Add(new Club { Name = "Jagiellonia Białystok", League = "Ekstraklasa", City = "Białystok", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737712/clubs/jagiellonia_bialystok_atf5np.png" });
                _context.Clubs.Add(new Club { Name = "KGHM Zagłębie Lubin", League = "Ekstraklasa", City = "Lubin", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737722/clubs/zaglebie_lubin_kcmbny.png" });
                _context.Clubs.Add(new Club { Name = "Korona Kielce", League = "Ekstraklasa", City = "Kielce", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737712/clubs/korona_kielce_pw1erc.png" });
                _context.Clubs.Add(new Club { Name = "Lech Poznań", League = "Ekstraklasa", City = "Poznań", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737727/clubs/lech_poznan_oae8go.png" });
                _context.Clubs.Add(new Club { Name = "Lechia Gdańsk", League = "Ekstraklasa", City = "Gdańsk", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737731/clubs/lechia_gdansk_tpivku.png" });
                _context.Clubs.Add(new Club { Name = "Legia Warszawa", League = "Ekstraklasa", City = "Warszawa", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737717/clubs/legia_warszawa_wdo7sr.png" });
                _context.Clubs.Add(new Club { Name = "ŁKS Łódź", League = "Ekstraklasa", City = "Łódź", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577737714/clubs/lks_lodz_pijjhl.png" });
                _context.Clubs.Add(new Club { Name = "Piast Gliwice", League = "Ekstraklasa", City = "Gliwice", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/piast_gliwice_mfrnc8.png" });
                _context.Clubs.Add(new Club { Name = "Pogoń Szczecin", League = "Ekstraklasa", City = "Szczecin", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/pogon_szczecin_ap02ma.png" });
                _context.Clubs.Add(new Club { Name = "Raków Częstochowa", League = "Ekstraklasa", City = "Częstochowa", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/rakow_czestochowa_rws7cp.png" });
                _context.Clubs.Add(new Club { Name = "Śląsk Wrocław", League = "Ekstraklasa", City = "Wrocław", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/slask_wroclaw_njfubp.png" });
                _context.Clubs.Add(new Club { Name = "Wisła Kraków", League = "Ekstraklasa", City = "Kraków", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/wisla_krakow_l4mlhg.png" });
                _context.Clubs.Add(new Club { Name = "Wisła Płock", League = "Ekstraklasa", City = "Płock", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577971431/clubs/wisla_plock_e4h2vq.png" });

                //I Liga
                _context.Clubs.Add(new Club { Name = "Warta Poznań", League = "I Liga", City = "Poznań", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/warta_poznan_jyvhbc.png" });
                _context.Clubs.Add(new Club { Name = "Stal Mielec", League = "I Liga", City = "Mielec", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/stal_mielec_p2u1ao.png" });
                _context.Clubs.Add(new Club { Name = "Podbeskidzie Bielsko-Biała", League = "I Liga", City = "Bielsko-Biała", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/podbeskidzie_bielsko-biala_veo8st.png" });
                _context.Clubs.Add(new Club { Name = "Radomiak Radom", League = "I Liga", City = "Radom", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/radomiak_radom_odxqm4.png" });
                _context.Clubs.Add(new Club { Name = "Olimpia Grudziądz", League = "I Liga", City = "Grudziądz", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/olimpia_grudziadz_fuwbrg.png" });
                _context.Clubs.Add(new Club { Name = "Miedź Legnica", League = "I Liga", City = "Legnica", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/miedz_legnica_aaxwkb.png" });
                _context.Clubs.Add(new Club { Name = "GKS Tychy", League = "I Liga", City = "Tychy", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/gks_tychy_o1jmqz.png" });
                _context.Clubs.Add(new Club { Name = "GKS 1962 Jastrzębie", League = "I Liga", City = "Jastrzębie Zdrój", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/gks_jastrzebie_iglzpd.png" });
                _context.Clubs.Add(new Club { Name = "Bruk-Bet Termalica Nieciecza", League = "I Liga", City = "Nieciecza", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/termalica_nieciecza_mbxerq.png" });
                _context.Clubs.Add(new Club { Name = "Zagłębie Sosnowiec", League = "I Liga", City = "Sosnowiec", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/zaglebie_sosnowiec_efilic.png" });
                _context.Clubs.Add(new Club { Name = "Stomil Olsztyn", League = "I Liga", City = "Olsztyn", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/stomil_olsztyn_idcgse.png" });
                _context.Clubs.Add(new Club { Name = "Sandecja Nowy Sącz", League = "I Liga", City = "Nowy Sącz", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/sandecja_nowy_sacz_plwy1f.png" });
                _context.Clubs.Add(new Club { Name = "GKS Bełchatów", League = "I Liga", City = "Bełchatów", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/gks_belchatow_jazw8j.png" });
                _context.Clubs.Add(new Club { Name = "Puszcza Niepołomice", League = "I Liga", City = "Niepołomice", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/puszcza_niepolomice_pilxn5.png" });
                _context.Clubs.Add(new Club { Name = "Odra Opole", League = "I Liga", City = "Opole", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/odra_opole_c1qdtw.png" });
                _context.Clubs.Add(new Club { Name = "Chrobry Głogów", League = "I Liga", City = "Głogów", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976309/clubs/chrobry_glogow_yjkq1k.png" });
                _context.Clubs.Add(new Club { Name = "Wigry Suwałki", League = "I Liga", City = "Suwałki", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/wigry_suwalki_tuitdg.png" });
                _context.Clubs.Add(new Club { Name = "Chojniczanka Chojnice", League = "I Liga", City = "Chojnice", LogoUri = "https://res.cloudinary.com/dgw0ykvfe/image/upload/v1577976310/clubs/chojniczanka_chojnice_b0vwqw.png" });

                _context.SaveChangesAsync();
            }
        }
    }
}
