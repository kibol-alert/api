using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Models
{
    public class ClubRelation
    {
        public int FirstClubId { get; set; }
        public Club FirstClub { get; set; }
        public int SecondClubId { get; set; }
        public Club SecondClub { get; set; }
        public RelationType Relation { get; set; }
    }

    public enum RelationType
    {
        Beef = 1,
        Tie
    }
}
