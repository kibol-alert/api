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
        [JsonConstructor]
        public Response( bool success) {
            Console.WriteLine(success);
            Success = success;
        }

        public bool Success { get; set; }
    }
}
