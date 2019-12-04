using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Models;
using Kibol_Alert.Services.ServiceResponses;
using Kibol_Alert.Requests;
using Kibol_Alert.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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

<<<<<<< HEAD
        public async Task<Response> Register(RegisterRequest request)
        {
            if (Context.Users.Any(i => i.Email == request.Email))
                return new ErrorResponse("Email Error");
            if (request.Password != request.ConfirmedPassword)
                return new ErrorResponse("Passwords are not the same");
=======
        public async Task<bool> Register(RegisterRequest request)
        {
            if (Context.Users.Any(i => i.Email == request.Email))
                return bool.Error("Email Error");
            if (request.Password != request.ConfirmedPassword)
                return bool.Error("Passwords are not the same");
>>>>>>> 9f3df8fd36da9c4a3d10606cc334651f8e075636

            var user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,
<<<<<<< HEAD
                ClubId = request.ClubId
=======
>>>>>>> 9f3df8fd36da9c4a3d10606cc334651f8e075636
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
<<<<<<< HEAD
                return new ErrorResponse("test");
            }
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> Login(LoginRequest request)
=======
                return bool.Error();
            }
            return bool.Ok();
        }

        public async Task<JwtToken> Login(LoginRequest request)
>>>>>>> 9f3df8fd36da9c4a3d10606cc334651f8e075636
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);

            if (!result.Succeeded)
<<<<<<< HEAD
                return new ErrorResponse("Login failed");
=======
                return JwtToken.Error("Login failed");
>>>>>>> 9f3df8fd36da9c4a3d10606cc334651f8e075636

            var token = _jwtHelper.GenerateJwtToken(request.UserName);
            if (token == null)
            {
<<<<<<< HEAD
                return new ErrorResponse("User doesn't exist");
            }
            return new SuccessResponse<JwtToken>(token);
        }

        public async Task<Response> Logout()
        {
            await _signInManager.SignOutAsync();
            return new SuccessResponse<bool>(true);
=======
                return JwtToken.Error("User doesn't exist");
            }
            return JwtToken.Ok(token);
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return bool.Ok();
>>>>>>> 9f3df8fd36da9c4a3d10606cc334651f8e075636
        }
    }
}
