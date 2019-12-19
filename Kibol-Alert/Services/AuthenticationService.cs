using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Kibol_Alert.Responses;

namespace Kibol_Alert.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    { 
        private readonly SignInManager<User> _signInManager = null;
        private readonly UserManager<User> _userManager = null;
        private readonly IJwtHelper _jwtHelper;

        public AuthenticationService(Kibol_AlertContext context, SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtHelper jwtHelper) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        public async Task<Response> Register(RegisterRequest request)
        {
            if (Context.Users.Any(i => i.Email == request.Email))
                return new ErrorResponse("Błędny email!\nPrawidłowy format: example@example.com");
            if (request.Password != request.ConfirmedPassword)
                return new ErrorResponse("Hasła nie są identyczne");

            var user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,
                ClubId = request.ClubId
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new ErrorResponse("Rejestracja się nie powiodła");
            }
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> Login(LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);

            if (!result.Succeeded)
                return new ErrorResponse("Ksywa lub hasło jest błędne!");

            var token = _jwtHelper.GenerateJwtToken(request.UserName);
            if (token == null)
            {
                return new ErrorResponse("Nie znaleziono użytkownika");
            }
            return new SuccessResponse<JwtToken>(token);
        }

        public async Task<Response> Logout()
        {
            await _signInManager.SignOutAsync();
            return new SuccessResponse<bool>(true);
        }
    }
}