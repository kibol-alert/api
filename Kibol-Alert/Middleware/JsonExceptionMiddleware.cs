using Kibol_Alert.Responses.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kibol_Alert.Middleware
{
    public class JsonExceptionMiddleware
    {
        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
                return;

            context.Response.ContentType = "application/json";

            var errorResponse = new ApiErrorResponse(ex.Message);

            var response = Newtonsoft.Json.JsonConvert.SerializeObject(errorResponse);

            await context.Response.WriteAsync(response);
        }
    }
}
