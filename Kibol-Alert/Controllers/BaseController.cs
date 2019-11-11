using System.Net;
using Kibol_Alert.Responses.Wrappers.Factories;
using Kibol_Alert.Services.ServiceResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kibol_Alert.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Responses.Wrappers.ApiValidationErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Responses.Wrappers.ApiValidationErrorResponse))]
    public class BaseController : ControllerBase
    {
        protected IApiResponseFactory _responseFactory { get; set; }

        public BaseController(IApiResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected ObjectResult CreateErrorResponse(HttpStatusCode code, string errorMessage) => StatusCode((int)code, _responseFactory.Error(errorMessage));

        protected ObjectResult CreateSuccessResponse<T>(T data) => StatusCode((int)HttpStatusCode.OK, _responseFactory.Success(data));

        protected ObjectResult ResolveServiceResponse<T>(ServiceResponse<T> serviceResponse) => serviceResponse.Success ? CreateSuccessResponse(serviceResponse.Data) : CreateErrorResponse(HttpStatusCode.BadRequest, serviceResponse.Message);

    }
}