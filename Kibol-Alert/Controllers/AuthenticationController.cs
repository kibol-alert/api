using Kibol_Alert.Responses.Wrappers;
using Kibol_Alert.Responses.Wrappers.Factories;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Requests;
using Kibol_Alert.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Kibol_Alert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IApiResponseFactory responseFactory, IAuthenticationService authenticationService) : base(responseFactory)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public IActionResult Register(RegisterRequest request) => ResolveServiceResponse(_authenticationService.Register(request));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<JwtToken>))]
        public IActionResult Login(LoginRequest request) => ResolveServiceResponse(_authenticationService.Login(request));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<bool>))]
        public IActionResult Logout() => ResolveServiceResponse(_authenticationService.Logout());
    }
}