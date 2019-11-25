using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Responses.Wrappers
{
    public class ApiErrorResponse : ApiResponse
    {
        public string Message { get; set; }

        public ApiErrorResponse(string message) : base(false)
        {
            Message = message;
        }
    }
}
