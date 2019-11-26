using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Responses
{
    public class Response
    {
        public Response() { }
        public Response(bool success) {
            Success = success;
        }
        public Response(string message, bool success) {
            Message = message;
            Success = success;
        }
        [JsonConstructor]
        public Response( object result, bool success) {
            Result = result;
            Success = success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
        public object Result { get; set; }
    }
}
