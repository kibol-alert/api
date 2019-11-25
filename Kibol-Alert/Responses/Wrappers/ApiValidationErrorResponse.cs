using System.Collections.Generic;

namespace Kibol_Alert.Responses.Wrappers
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public Dictionary<string,List<string>> Errors { get; set; }

        public ApiValidationErrorResponse(Dictionary<string,List<string>> errorDictionary) : base(false)
        {
            Errors = errorDictionary;
        }
    }
}
