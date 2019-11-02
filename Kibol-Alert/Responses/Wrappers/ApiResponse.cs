using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Responses.Wrappers
{
    public abstract class ApiResponse
    {
        public bool Success { get; set; }

        public ApiResponse(bool success)
        {
            Success = success;
        }
    }
}
