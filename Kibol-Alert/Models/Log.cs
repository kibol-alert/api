using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string TimeStamp { get; set; } = String.Format("{0:g}", DateTime.Now);
    }
}
