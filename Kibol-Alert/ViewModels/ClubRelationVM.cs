namespace Kibol_Alert.ViewModels
{
    public class ClubRelationVM
    {
        public int FirstClubId { get; set; }
        public ClubVM FirstClub { get; set; }
        public int SecondClubId { get; set; }
        public ClubVM SecondClub { get; set; }
        public RelationType Relation { get; set; }
    }

    public enum RelationType
    {
        Beef = 1,
        Tie
    }
}
