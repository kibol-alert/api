using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class ClubRelation
    {
        public Club FirtClub { get; set; }
        public Club SecondClub { get; set; }
        enum RelationType
        {
            Beef = 1,
            Tie
        }
    }
}
