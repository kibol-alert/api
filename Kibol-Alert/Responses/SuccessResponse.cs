using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Responses
{
    public class SuccessResponse<T> : Response
    {
        public SuccessResponse() : base(true)
        {
        }
        public SuccessResponse(T responseData)
            : base(responseData, true)
        {
        }
    }
}
