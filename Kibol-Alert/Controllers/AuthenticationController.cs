using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Requests;
using Kibol_Alert.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoWrapper.Wrappers;
using Kibol_Alert.Responses;
using System.Net;

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
        public async Task<IActionResult> Register(RegisterRequest request) => ResolveResponse( await _authenticationService.Register(request));

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        //public async Task<ApiResponse> Login(LoginRequest request) => => _authenticationService.Login(request);

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        //public async Task<ApiResponse> Logout() => => _authenticationService.Logout();
    }
}