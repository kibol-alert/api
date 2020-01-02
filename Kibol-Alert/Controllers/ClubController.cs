using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.ViewModels;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Responses;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class ClubController : BaseController
    {
        private readonly IClubService _clubsService;
        public ClubController(IClubService clubService)
        {
            _clubsService = clubService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<ClubVM>>))]
        public async Task<IActionResult> GetClubs(int skip, int take) => ResolveResponse(await _clubsService.GetClubs(skip, take));

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<ClubVM>))]
        public async Task<IActionResult> GetClub(int id) => ResolveResponse(await _clubsService.GetClub(id));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> AddClub(ClubRequest request) => ResolveResponse(await _clubsService.AddClub(request));


        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> DeleteClub(int id) => ResolveResponse(await _clubsService.DeleteClub(id));


        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> EditClub(int id, ClubRequest request) => ResolveResponse(await _clubsService.EditClub(id, request));


        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> AddRelation(ClubRelationRequest request) => ResolveResponse(await _clubsService.AddRelation(request));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> DeleteRelation(int id) => ResolveResponse(await _clubsService.DeleteRelation(id));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> AddChant(ClubChantRequest request) => ResolveResponse(await _clubsService.AddChant(request));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> EditChant(int id, ClubChantRequest request) => ResolveResponse(await _clubsService.EditChant(id, request));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> DeleteChant(int id) => ResolveResponse(await _clubsService.DeleteChant(id));
    }
}
