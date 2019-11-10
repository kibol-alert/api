using Kibol_Alert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Requests
{
    public class ClubRelationRequest
    {
        public Club FirtClub { get; set; }
        public Club SecondClub { get; set; }
    }
}
