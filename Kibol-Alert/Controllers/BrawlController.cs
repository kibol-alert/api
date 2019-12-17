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
    [Authorize]
    public class BrawlController : BaseController
    {
        private readonly IBrawlService _brawlsService;
        public BrawlController(IBrawlService brawlService)
        {
            _brawlsService = brawlService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<BrawlVM>>))]
        public async Task<IActionResult> GetBrawls(int skip, int take) => ResolveResponse(await _brawlsService.GetBrawls(skip, take));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<BrawlVM>))]
        public async Task<IActionResult> GetBrawl(int id) => ResolveResponse(await _brawlsService.GetBrawl(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> AddBrawl(BrawlRequest request) => ResolveResponse(await _brawlsService.AddBrawl(request));


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<bool>))]
        public async Task<IActionResult> DeleteBrawl(int id) => ResolveResponse(await _brawlsService.DeleteBrawl(id));


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<ClubVM>))]
        public async Task<IActionResult> EditBrawl(int id, BrawlRequest request) => ResolveResponse(await _brawlsService.EditBrawl(id, request));
    }
}
