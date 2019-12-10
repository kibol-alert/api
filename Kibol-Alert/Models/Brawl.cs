using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class Brawl
    {
        public int Id { get; set; }
        public Club FirstClub { get; set; }
        public Club SecondClub { get; set; }
    }
}
