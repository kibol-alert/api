using Newtonsoft.Json;
using System;

namespace Kibol_Alert.Responses
{
    public class Response
    {
        public Response() { }
        [JsonConstructor]
        public Response(bool success)
        {
            Console.WriteLine(success);
            Success = success;
        }

        public bool Success { get; set; }
    }
}
