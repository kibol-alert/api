using Kibol_Alert.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kibol_Alert.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public class BaseController : ControllerBase
    {

        public BaseController()
        {
        }
        protected IActionResult CreateErrorResponse<T>(T data) => StatusCode((int)HttpStatusCode.BadRequest, data);

        protected IActionResult CreateSuccessResponse<T>(T data) => StatusCode((int)HttpStatusCode.OK, data);

        protected IActionResult ResolveResponse(Response service) => service.Success ? CreateSuccessResponse(service) : CreateErrorResponse(service);


    }
}
