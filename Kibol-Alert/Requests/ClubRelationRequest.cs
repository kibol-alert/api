using Kibol_Alert.Models;

namespace Kibol_Alert.Requests
{
    public class ClubRelationRequest
    {
        public int FirstClubId { get; set; }
        public int SecondClubId { get; set; }
        public RelationType Relation { get; set; }
    }
}