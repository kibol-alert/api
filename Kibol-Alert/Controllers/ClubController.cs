using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.ViewModels;
using Kibol_Alert.Services.Interfaces;
using AutoWrapper.Wrappers;


namespace Kibol_Alert.Controllers
{/*
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClubController
    {
        private readonly IClubService _clubsService;
        public ClubController(ApiResponse apiResponse, IClubService clubService)
           : base(responseFactory)
        {
            _clubsService = clubService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<IEnumerable<ClubVM>>))]
        public async Task<ApiResponse> GetClubs(int skip, int take) => ResolveServiceResponse(await _clubsService.GetClubs(skip, take));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> GetClub(int id) => ResolveServiceResponse(await _clubsService.GetClub(id));
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> AddClub(string name, string logoUri) => ResolveServiceResponse(await _clubsService.AddClub(string name, string logoUri));
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> DeleteClub(string name, string logoUri) => ResolveServiceResponse(await _clubsService.DeleteClub(int Id));
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> EditClub(string name, string logoUri) => ResolveServiceResponse(await _clubsService.EditClub(int id, string name, string logoUri));
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> AddRelation(string name, string logoUri) => ResolveServiceResponse(await _clubsService.AddRelation(ClubRelation relation));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiSuccessResponse<ClubVM>))]
        public async Task<IActionResult> DeleteRelation(string name, string logoUri) => ResolveServiceResponse(await _clubsService.AddRelation(ClubRelation relation));
    }
    */
}
