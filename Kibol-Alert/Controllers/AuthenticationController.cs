using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kibol_Alert.Controllers
{
    [Produces("application/json")]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> Register(RegisterRequest request) => ResolveResponse(await _authenticationService.Register(request));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<JwtToken>))]
        public async Task<IActionResult> Login(LoginRequest request) => ResolveResponse(await _authenticationService.Login(request));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> Logout() => ResolveResponse(await _authenticationService.Logout());
    }
}