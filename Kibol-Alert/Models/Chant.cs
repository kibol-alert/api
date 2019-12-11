using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class Chant
    {
        public int Id { get; set; }
        public Club Club { get; set; }
        public string Text { get; set; }
    }
}
