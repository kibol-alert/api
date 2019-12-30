using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.ViewModels;
using Kibol_Alert.Responses;
using Kibol_Alert.Requests;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Models;

namespace Kibol_Alert.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _usersService;
        public UserController(IUserService userService)
        {
            _usersService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<UserVM>>))]
        public async Task<IActionResult> GetUsers(int skip, int take) => ResolveResponse(await _usersService.GetUsers(skip, take));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<UserVM>))]
        public async Task<IActionResult> GetUser(string id) => ResolveResponse(await _usersService.GetUser(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> DeleteUser(string id) => ResolveResponse(await _usersService.DeleteUser(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> BanUser(string id) => ResolveResponse(await _usersService.BanUser(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> UnbanUser(string id) => ResolveResponse(await _usersService.UnbanUser(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> GivenAdmin(string id) => ResolveResponse(await _usersService.GiveAdmin(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> TakeAdmin(string id) => ResolveResponse(await _usersService.TakeAdmin(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> EditUser(string id, UserRequest request) => ResolveResponse(await _usersService.EditUser(id, request));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<Log>>))]
        public async Task<IActionResult> GetLogs() => ResolveResponse(await _usersService.GetLogs());
    }
}
