using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Kibol_Alert.Models;
using Kibol_Alert.Helpers;
using Kibol_Alert.Services.Interfaces;
using System;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.Database;

namespace Kibol_Alert.Services
{
    public class JwtHelper : IJwtHelper
    {
        private readonly Kibol_AlertContext _context;
        private readonly AppSettings _appSettings;


        public JwtHelper(IOptions<AppSettings> appSettings, Kibol_AlertContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;

        }


        JwtToken IJwtHelper.GenerateJwtToken(string username)
        {
            User user = _context.Users.SingleOrDefault(i => i.UserName == username);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = new JwtToken()
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            };
            return token;
        }
    }
}
