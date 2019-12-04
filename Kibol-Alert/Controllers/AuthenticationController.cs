using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Requests;
using Kibol_Alert.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoWrapper.Wrappers;

namespace Kibol_Alert.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse> Register(RegisterRequest request)

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse> Login(LoginRequest request)

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof())]
        public async Task<ApiResponse> LogoutAsync()
    }
}